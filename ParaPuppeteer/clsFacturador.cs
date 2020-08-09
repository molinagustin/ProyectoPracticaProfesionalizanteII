using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;
using Facturas;
using entProducto;


namespace ParaPuppeteer
{
    public class clsFacturador
    {
        #region "Campos"
        private String _URL = "https://auth.afip.gob.ar/contribuyente_/login.xhtml";
        private string _URLComprobantes = "https://serviciosjava2.afip.gob.ar/";
        private string _Path = "D:\\Chromium";
        private Browser _Browser;
        private Page _Page;
        private Page _NewPage;
        private LaunchOptions _Options;
        private String _CUIL;
        private String _Password;
        private eEncabezadoComprobante _Encabezado;
        private List<eCuerpoComprobante> _Items;
        private List<eProducto> _ListaProductos;
        #endregion

        #region "Propiedades"
        public string URL
        {
            get
            {
                return _URL;
            }

            set
            {
                _URL = value;
            }
        }

        public string URLComprobantes
        {
            get
            {
                return _URLComprobantes;
            }

            set
            {
                _URLComprobantes = value;
            }
        }

        public string Path
        {
            get
            {
                return _Path;
            }

            set
            {
                _Path = value;
            }
        }

        public Browser Browser
        {
            get
            {
                return _Browser;
            }

            set
            {
                _Browser = value;
            }
        }

        public Page Page
        {
            get
            {
                return _Page;
            }

            set
            {
                _Page = value;
            }
        }

        public Page NewPage
        {
            get
            {
                return _NewPage;
            }

            set
            {
                _NewPage = value;
            }
        }

        public LaunchOptions Options
        {
            get
            {
                return _Options;
            }

            set
            {
                _Options = value;
            }
        }

        public string CUIL
        {
            get
            {
                return _CUIL;
            }

            set
            {
                _CUIL = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public eEncabezadoComprobante Encabezado
        {
            get
            {
                return _Encabezado;
            }

            set
            {
                _Encabezado = value;
            }
        }

        public List<eCuerpoComprobante> Items
        {
            get
            {
                return _Items;
            }

            set
            {
                _Items = value;
            }
        }

        public List<eProducto> ListaProductos
        {
            get
            {
                return _ListaProductos;
            }

            set
            {
                _ListaProductos = value;
            }
        }
        #endregion

        #region "Contructores" 
        public clsFacturador() { }
        public clsFacturador(eEncabezadoComprobante encabezado, List<eCuerpoComprobante> items, List<eProducto> listaprod)
        {
            this.Encabezado = encabezado;
            this.Items = items;
            this.ListaProductos = listaprod;
        }

        #endregion

        #region "Funciones"
        //Se descarga el navegador chromium
        public async Task<bool> DescargarNavegador()
        {
            BrowserFetcher browserFetcher = new BrowserFetcher(new BrowserFetcherOptions
            {
                Path = this.Path
            });

            RevisionInfo res = await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);
            this.Options = new LaunchOptions
            {
                //Args = ...,
                Headless = false,
                ExecutablePath = browserFetcher.GetExecutablePath(BrowserFetcher.DefaultRevision),
                DefaultViewport = null,
                Timeout = 10000
            };
            return res.Downloaded;
        }

        //se abre el navegador Chromium
        public async Task AbrirNavegador()
        {
            try
            {
                this.Browser = await Puppeteer.LaunchAsync(Options);
                this.Page = await Browser.NewPageAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo abrir el navegador", ex);
            }


        }
        //Se dirige a la pagina de la afip
        public async Task IrPagAfip()
        {
            //Aca se impide que el navegador carge contenido de la pagina para lograr que la navegacion sea mas rapida
            await Page.SetRequestInterceptionAsync(true);
            Page.Request += (sender, e) =>
            {
                if (e.Request.ResourceType == ResourceType.Image)
                {
                    e.Request.AbortAsync();
                }
                else
                {
                    e.Request.ContinueAsync();
                }
            };

            try
            {
                await Page.GoToAsync(this.URL);
                     
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

        }

        //funcion donde se hace login en la pagina de AFIP. Se ingresa el cuil
        public async Task IngresoCUIT()
        {
            //var btnIngr = await Page.QuerySelectorAsync("#F1\\:btnSiguiente"); ///buscar algo para esperar
            try
            {
                //se ingresa el cuil luego se presiona el boton enter
                await Page.Keyboard.TypeAsync(this.CUIL);
                await Page.Keyboard.PressAsync("Enter");
                await Page.WaitForNavigationAsync();
                //await Page.WaitForTimeoutAsync(8000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        //se ingresa la contraseña
        public async Task IngresoPass()
        {
            var btnIngr = await Page.QuerySelectorAsync("#F1\\:btnSiguiente"); ///buscar algo para esperar
            try
            {
                await Page.Keyboard.TypeAsync(this.Password);
                await Page.Keyboard.PressAsync("Enter");
                await Page.WaitForNavigationAsync();
                //await Page.WaitForTimeoutAsync(8000);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //funcion que llega a la pagina de comprobantes en linea de AFIP
        public async Task IrAComprobantesEnLinea()
        {
            await Page.WaitForTimeoutAsync(8000);
            //Se selecciona el boton de comprobantes en linea
            //await Page.WaitForSelectorAsync("document.querySelector("#servicesContainer > div:nth-child(8) > div > div > div > div.media-body > h4")
            try
            {
                await Page.WaitForSelectorAsync("#servicesContainer > div:nth-child(8) > div > div > div > div.media-body > h4");
                ElementHandle btnComprantes = await Page.QuerySelectorAsync("#servicesContainer > div:nth-child(8) > div > div > div > div.media-body > h4");

                if (btnComprantes != null)
                {
                    await btnComprantes.ClickAsync();

                    //Este evento detecta la pestaña de comprobantes en linea que se abre al hacer click
                    Browser.TargetCreated += async (sender, e) =>
                    {
                        if (e.Target.Url.Substring(0, URLComprobantes.Length).Equals(URLComprobantes))
                        {
                            NewPage = await e.Target.PageAsync();
                        }
                    };
                }
                else
                {
                    throw new Exception("No se detecta el boton de comprobantes en linea");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

        }

        public async Task IngresarEmpresa()
        {
            //Se selecciona la empresa ### document.querySelector("#contenido > form > table > tbody > tr:nth-child(4) > td > input.btn_empresa.ui-button.ui-widget.ui-state-default.ui-corner-all.ui-state-hover")
            try
            {
                await Page.WaitForTimeoutAsync(4000);


                ElementHandle btnEmpresa = await NewPage.QuerySelectorAsync("#contenido > form > table > tbody > tr:nth-child(4) > td > input.btn_empresa.ui-button.ui-widget.ui-state-default.ui-corner-all");

                if (btnEmpresa != null)
                {
                    await btnEmpresa.ClickAsync();
                }
                else
                {
                    await Page.WaitForTimeoutAsync(4000);
                    ElementHandle btnEmpresa2 = await NewPage.QuerySelectorAsync("#contenido > form > table > tbody > tr:nth-child(4) > td > input.btn_empresa.ui-button.ui-widget.ui-state-default.ui-corner-all");
                    await btnEmpresa2.ClickAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarEncabezado()
        {
            try
            {
                var btnGenerarComprantes = await NewPage.QuerySelectorAsync("#btn_gen_cmp > span.ui-button-text");
                if (btnGenerarComprantes != null)
                {
                    await btnGenerarComprantes.ClickAsync();
                    await NewPage.WaitForNavigationAsync();
                    //await NewPage.WaitForSelectorAsync("#universocomprobante > option:nth-child(2)");
                }
                else
                {
                    throw new Exception("No se detecta el boton generar Comprobantes");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<string[]> IngresarPuntoVenta(string ptoventa = "3")
        {
            //selector donde se seleccionan los puntos de venta document.querySelector("#puntodeventa > option:nth-child(2)")
            try
            {
                string[] puntos = await NewPage.SelectAsync("select#puntodeventa");
                await NewPage.SelectAsync("select#puntodeventa", ptoventa);
                await Page.WaitForTimeoutAsync(1000);

                return puntos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarTipoComp()
        {
            try
            {
                //se selecciona el tipo de comprobante 
                switch (Encabezado.TipoComprobante)
                {
                    case 3: // Factura c
                        await NewPage.SelectAsync("select#universocomprobante", "2");
                        break;
                    case 4: //nota debito
                        await NewPage.SelectAsync("select#universocomprobante", "3");
                        break;
                    case 5: // nota credito
                        await NewPage.SelectAsync("select#universocomprobante", "4");
                        break;

                        //se presona el boton siguiente para pasar al siguiente formulario
                }
                var btnSiguiente = await NewPage.QuerySelectorAsync("#contenido > form > input[type=button]:nth-child(4)");
                if (btnSiguiente != null)
                {
                    await btnSiguiente.ClickAsync();
                    await NewPage.WaitForNavigationAsync();
                }
                else
                {
                    throw new Exception("No se detecta el boton siguiente de tipocomp");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarFecha()
        {
            try
            {
                var inputFecha = await NewPage.QuerySelectorAsync("#fc");
                if (inputFecha != null)
                {
                    //Se ingresa la fecha en el input correspondiente el  formato dd/MM/yyyy
                    await inputFecha.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", (Encabezado.Fecha.ToString("dd/MM/yyyy")));
                }
                else
                {
                    throw new Exception("No se ha podido ingresar la fecha del comprobante");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarConcepIncluir()
        {
            try
            {
                switch (Encabezado.ConceptoInc)
                {
                    case "Productos":
                        await NewPage.SelectAsync("select#idconcepto", "1");
                        break;
                    case "Servicios":
                        await NewPage.SelectAsync("select#idconcepto", "2");
                        break;
                    case "Productos/Servicios":
                        await NewPage.SelectAsync("select#idconcepto", "3");
                        break;
                }
                //se presona el boton siguiente para pasar al siguiente formulario
                var btnSiguiente2 = await NewPage.QuerySelectorAsync("#contenido > form > input[type=button]:nth-child(4)");
                if (btnSiguiente2 != null)
                {
                    await btnSiguiente2.ClickAsync();
                    await NewPage.WaitForNavigationAsync();
                }
                else
                {
                    throw new Exception("No se encuentra boton sig en concepto a incluir");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarCondIVA()
        {
            try
            {
                //switch case donde se selecciona la condicion del iva del receptor de la factura
                switch (Encabezado.CondicionIva)
                {
                    case 1://consumidor final
                        await NewPage.SelectAsync("select#idivareceptor", "1");
                        break;
                    case 2: //IVA inscripto
                        await NewPage.SelectAsync("select#idivareceptor", "3");
                        break;
                    case 3://consumidor final
                        await NewPage.SelectAsync("select#idivareceptor", "5");
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarTipoDoc(int TipoDoc)
        {
            try
            {
                //switch case donde se selecciona el tipo de documentodocument.querySelector("#idtipodocreceptor")
                switch (TipoDoc)
                {
                    case 1: //CUIT
                        await NewPage.SelectAsync("select#idtipodocreceptor", "80");
                        break;
                    case 2: //CDI
                        await NewPage.SelectAsync("select#idtipodocreceptor", "87");
                        break;
                    case 3: //LE
                        await NewPage.SelectAsync("select#idtipodocreceptor", "89");
                        break;
                    case 4: //LC
                        await NewPage.SelectAsync("select#idtipodocreceptor", "90");
                        break;
                    case 5: //CI Extranjera
                        await NewPage.SelectAsync("select#idtipodocreceptor", "91");
                        break;
                    case 6: //DNI
                        await NewPage.SelectAsync("select#idtipodocreceptor", "96");
                        break;
                    case 7: //Pasaporte
                        await NewPage.SelectAsync("select#idtipodocreceptor", "94");
                        break;
                    case 8: //CI policia Federal
                        await NewPage.SelectAsync("select#idtipodocreceptor", "00");
                        break;
                    case 9: //Certificado de migracion
                        await NewPage.SelectAsync("select#idtipodocreceptor", "30");
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public async Task IngresarNroDoc(string NumeroDoc)
        {
            try
            {
                var inputNroDocumento = await NewPage.QuerySelectorAsync("#nrodocreceptor");
                if (inputNroDocumento != null)
                {
                    //Se ingresa el nro de documento
                    if (NumeroDoc.Length != 0)
                    {
                        await inputNroDocumento.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", NumeroDoc);
                    }
                }
                else
                {
                    throw new Exception("No se ha podido ingresar el numero de documento");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarFormaPago(string NroPago, string NroTarjeta = "")
        {
            try
            {
                string Forma = "#formadepago";
                switch (Encabezado.FormaPago)
                {
                    case 1://Contado
                        NroPago = "1";
                        break;
                    case 2:// Tarjeta debito
                        NroPago = "2";
                        break;
                    case 3: //Tarjeta debito
                        NroPago = "3";
                        break;
                    case 4: //Cuenta Corriente
                        NroPago = "4";
                        break;
                    case 5: //Cheque
                        NroPago = "5";
                        break;
                    case 6: //Ticket
                        NroPago = "6";
                        break;
                    case 7: //Otro
                        NroPago = "7";
                        break;

                }
                var inputFormaPago = await NewPage.QuerySelectorAsync(Forma + NroPago);
                if (inputFormaPago != null)
                {
                    await inputFormaPago.ClickAsync();

                    if (NroPago == "2" || NroPago == "3")
                    {
                        string IdTarjeta = NroPago == "2" ? "#tarjeta_nro_debito1" : "#tarjeta_nro_credito1";

                        var inputTarjeta = await NewPage.QuerySelectorAsync(IdTarjeta);
                        if (inputTarjeta != null)
                        {
                            //Se ingresa el nro de documento
                            if (NroTarjeta.Length != 0)
                            {
                                await inputTarjeta.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", NroTarjeta);
                            }
                        }
                    }

                    //se presona el boton siguiente para pasar al siguiente formulario
                    var btnSiguiente3 = await NewPage.QuerySelectorAsync("#formulario > input[type=button]:nth-child(4)");
                    if (btnSiguiente3 != null)
                    {
                        await btnSiguiente3.ClickAsync();
                    }

                    await NewPage.WaitForNavigationAsync();
                }
                else
                {
                    throw new Exception("No se ha podido ingresar la forma de pago");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task IngresarItems()
        {
            try
            {
                foreach (var item in Items)
                {
                    string Nro = Convert.ToString(item.IdCuerpo);
                    var txtProducto = await NewPage.QuerySelectorAsync("#detalle_descripcion" + Nro);
                    if (txtProducto != null)
                    {
                        //Se ingresa la fecha en el input correspondiente el  formato dd/MM/yyyy
                        await txtProducto.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", ListaProductos.Find((val) => val.IdProducto == item.ProductoServicio).NombreProducto);

                        var txtCantidad = await NewPage.QuerySelectorAsync("#detalle_cantidad" + Nro);
                        if (txtCantidad != null)
                        {
                            //Se ingresa el nombre del producto
                            await txtCantidad.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", Convert.ToString(item.Cantidad));
                            //la unidad de medida del producto
                            await NewPage.SelectAsync("#detalle_medida" + Nro, Convert.ToString(item.UnidadMedida));

                            var txtPrecio = await NewPage.QuerySelectorAsync("#detalle_precio" + Nro);
                            if (txtPrecio != null)
                            {
                                //Se ingresa el precio
                                await txtPrecio.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", ListaProductos.Find((val) => val.IdProducto == item.ProductoServicio).PrecioFinal.ToString("F", System.Globalization.CultureInfo.InvariantCulture));

                                var txtBoni = await NewPage.QuerySelectorAsync("#detalle_precio" + Nro);
                                if (txtBoni != null)
                                {
                                    //Se ingresa la bonificacion en caso de haberla
                                    if (item.Bonificacion != 0)
                                    {
                                        await txtBoni.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", Convert.ToString(item.Bonificacion));
                                    }
                                    //boton para agregar otro item

                                    if (Items.Count > 1 && !(Items.Count == item.IdCuerpo))
                                    {
                                        var botonAgregar = await NewPage.QuerySelectorAsync("#detalles_datos > input[type=button]");

                                        if (botonAgregar != null)
                                        {
                                            await botonAgregar.ClickAsync();
                                        }
                                        else
                                        {
                                            throw new Exception("No se detecta el boton otro item");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception("No se detecta el input de la bonificacion");
                                }


                            }
                            else
                            {
                                throw new Exception("No se detecta el input del precio del producto o servicio ");
                            }



                        }
                        else
                        {
                            throw new Exception("No se encuentra el input de la cantidad");
                        }


                    }
                    else
                    {
                        throw new Exception("No se detecta el input  del producto o servicio ");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> Terminar()
        {
            try
            {
                //document.querySelector("#contenido > form > input[type=button]:nth-child(15)")
                //Luego de ingresar los items se procede a finalizar con el proceso de facturacion 
                var botonTerminar = await NewPage.QuerySelectorAsync("#contenido > form > input[type=button]:nth-child(15)");

                if (botonTerminar != null)
                {
                    await botonTerminar.ClickAsync();
                    await NewPage.WaitForNavigationAsync();

                    var botonGenerar = await NewPage.QuerySelectorAsync("#btngenerar");
                
                    if (botonGenerar != null)
                    {
                        //await botonGenerar.ClickAsync();
                        //await NewPage.Keyboard.PressAsync("Enter");
                        //document.querySelector("#botones_comprobante > b")
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se detecta el boton generar");
                    }
                }
                else
                {
                    throw new Exception("No se detecta el boton terminar");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        

        public async Task Volver()
        {
            //document.querySelector("#contenido > table > tbody > tr:nth-child(2) > td > input[type=button]")
            var btnVolver = await NewPage.QuerySelectorAsync("#contenido > table > tbody > tr:nth-child(2) > td > input[type=button]");
            if (btnVolver != null)
                await btnVolver.ClickAsync();

            await NewPage.WaitForNavigationAsync();
        }
        public void Cerrar()
        {
            this.Browser.Dispose();
        }
        #endregion
    }
}
