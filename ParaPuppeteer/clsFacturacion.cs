using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;
using Facturas;




namespace ParaPuppeteer
{
    public class  clsFacturacion
    {
        private String URL = "https://auth.afip.gob.ar/contribuyente_/login.xhtml";
        private string URLComprobantes = "https://serviciosjava2.afip.gob.ar/";
        private string path = "D:\\Chromium";
        private Browser browser;
        private Page page;
        private Page newPage;
        private LaunchOptions options;
 
        public String CUIL { get; set; }
        public String PassWord { get; set; }

        public enum TipoComprobante { FacturaC, NotaDebito, NotaCredito}

        public enum ConceptosIncluir { Productos, Servicios, ProducosYServicios}

        public enum CondicionIVA { ConsumidoFinal, IVAInscripto}

        public enum TipoDocumento { DNI, CUIL, CUIT}

        public enum CondicionVenta { Contado, TarjetaCredito, TarjetaDebito}

        
  
        public async Task DescargarNavegador()
        {
            
            BrowserFetcher browserFetcher = new BrowserFetcher(new BrowserFetcherOptions
            {
                Path = this.path
            });


            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);

            this.options = new LaunchOptions
            {
                //Args = ...,
                Headless = false,
                ExecutablePath = browserFetcher.GetExecutablePath(BrowserFetcher.DefaultRevision),
                DefaultViewport = null,
                Timeout= 10000
            };


        }

        //se abre el navegador Chromium
        public async Task AbrirNavegador()
        {

            try
            {
                this.browser = await Puppeteer.LaunchAsync(options);
                this.page = await browser.NewPageAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
                Console.ReadKey();
            
            }
            
            
        }

    
        //funcion donde se hace login en la pagina de AFIP
        public async Task Ingreso()
        {
            await page.GoToAsync(this.URL);
            //se ingresa el cuil luego se presiona el boton enter
            await page.Keyboard.TypeAsync(this.CUIL);
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();
            //se ingresa luego la constraseña y luego se presiona la tecla enter
            await page.Keyboard.TypeAsync(this.PassWord);
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();

            await page.WaitForTimeoutAsync(8000);

        }
        //funcion que llega a la pagina de comprobantes en linea de AFIP
        public async Task IrAComprobantesEnLinea()
        {

            try
            {
                //
                //document.querySelector("#root > div > main > section:nth-child(3) > div > div:nth-child(3) > div.col-xs-12.col-md-5.col-sm-5.col-lg-5 > div.panel.panel-default.p-a-2.m-t-1 > div:nth-child(2) > div > div.media-body > h3")
                await page.WaitForSelectorAsync("#root > div > main > section:nth-child(3) > div > div:nth-child(3) > div.col-xs-12.col-md-5.col-sm-5.col-lg-5 > div.panel.panel-default.p-a-2.m-t-1 > div:nth-child(2) > div > div.media-left.small.text-center > i");
                var btnComprantes = await page.QuerySelectorAsync("#root > div > main > section:nth-child(3) > div > div:nth-child(3) > div.col-xs-12.col-md-5.col-sm-5.col-lg-5 > div.panel.panel-default.p-a-2.m-t-1 > div:nth-child(2) > div > div.media-left.small.text-center > i");
                if (btnComprantes != null)
                {
                    await btnComprantes.ClickAsync();

                } else
                {
                    System.Windows.Forms.MessageBox.Show("NO FUNCA EL BOTON");
                }

                await page.WaitForTimeoutAsync(4000);

                var pestanas = browser.Targets();
                Console.WriteLine("La pagina es: " + page.Url);
            
                foreach (var pes in pestanas)
                {
                    Console.WriteLine(pes.Url);
                    if (pes.Url.Length >= URLComprobantes.Length)
                    {
                        
                        if (pes.Url.Substring(0, URLComprobantes.Length).Equals(URLComprobantes))
                        {
                            newPage = await pes.PageAsync();
                        }
                    }
                }



                Console.WriteLine("La nueva pagina es: " + newPage.Url);



                
                //await newPage.WaitForSelectorAsync("#contenido > form > table > tbody > tr:nth-child(4) > td > input.btn_empresa.ui-button.ui-widget.ui-state-default.ui-corner-all");

                await newPage.WaitForTimeoutAsync(3000);
                var btnEmpresa = await newPage.QuerySelectorAsync("#contenido > form > table > tbody > tr:nth-child(4) > td > input.btn_empresa.ui-button.ui-widget.ui-state-default.ui-corner-all");

                if (btnEmpresa != null)
                {
                    await btnEmpresa.ClickAsync();
                }else
                {
                    Console.WriteLine("NO se que paso");
                }
                
                await newPage.WaitForNavigationAsync();


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw new Exception("");
            }

        }

        //public async Task GenerarComprobante(TipoComprobante tipoComprobante, string fechaComprobante, ConceptosIncluir Conceptos, CondicionIVA Condicion,
        //    TipoDocumento TipoDoc, string NroDocumento, CondicionVenta FormaPago)
        public async Task GenerarComprobante(TipoComprobante tipoComprobante, string fechaComprobante, ConceptosIncluir Conceptos, CondicionIVA Condicion,
            TipoDocumento TipoDoc, string NroDocumento, CondicionVenta FormaPago)
        {
            try
            {
                var btnGenerarComprantes = await newPage.QuerySelectorAsync("#btn_gen_cmp > span.ui-button-text");
                if (btnGenerarComprantes != null)
                {
                    await btnGenerarComprantes.ClickAsync();
                }
                else
                {
                    var btnGenerarComprantes2 = await newPage.QuerySelectorAsync("#btn_gen_cmp > span.ui-button-text");
                    await btnGenerarComprantes2.ClickAsync();
                }
                await newPage.WaitForNavigationAsync();

                //selector donde se seleccionan los puntos de venta
                await newPage.SelectAsync("select#puntodeventa", "3");

                await newPage.WaitForSelectorAsync("#universocomprobante > option:nth-child(2)");
                //se selecciona el tipo de comprobante 
                switch (tipoComprobante)
                {
                    case TipoComprobante.FacturaC:
                        await newPage.SelectAsync("select#universocomprobante", "2");
                        break;
                    case TipoComprobante.NotaDebito:
                        await newPage.SelectAsync("select#universocomprobante", "3");
                        break;
                    case TipoComprobante.NotaCredito:
                        await newPage.SelectAsync("select#universocomprobante", "4");
                        break;

                }


                //se presona el boton siguiente para pasar al siguiente formulario
                var btnSiguiente = await newPage.QuerySelectorAsync("#contenido > form > input[type=button]:nth-child(4)");
                if (btnSiguiente != null)
                {
                    await btnSiguiente.ClickAsync();
                }
                await newPage.WaitForNavigationAsync();

                var inputFecha = await newPage.QuerySelectorAsync("#fc");
                if (inputFecha != null)
                {
                    //Se ingresa la fecha en el input correspondiente el  formato dd/MM/yyyy
                    await inputFecha.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", fechaComprobante);

                }
                if (inputFecha == null)
                {
                    Console.WriteLine("NO funca");
                }

                switch (Conceptos)
                {
                    case ConceptosIncluir.Productos:
                        await newPage.SelectAsync("select#idconcepto", "1");
                        break;
                    case ConceptosIncluir.Servicios:
                        await newPage.SelectAsync("select#idconcepto", "2");
                        break;
                    case ConceptosIncluir.ProducosYServicios:
                        await newPage.SelectAsync("select#idconcepto", "3");
                        break;
                }
                //se presona el boton siguiente para pasar al siguiente formulario
                var btnSiguiente2 = await newPage.QuerySelectorAsync("#contenido > form > input[type=button]:nth-child(4)");
                if (btnSiguiente2 != null)
                {
                    await btnSiguiente2.ClickAsync();
                }

                await newPage.WaitForNavigationAsync();

                //switch case donde se selecciona la condicion del iva del receptor de la factura
                switch (Condicion)
                {
                    case CondicionIVA.ConsumidoFinal:
                        await newPage.SelectAsync("select#idivareceptor", "5");
                        break;
                    case CondicionIVA.IVAInscripto:
                        await newPage.SelectAsync("select#idivareceptor", "1");
                        break;
                }
                //switch case donde se selecciona el tipo de documento
                switch (TipoDoc)
                {
                    case TipoDocumento.DNI:
                        await newPage.SelectAsync("select#idtipodocreceptor", "96");
                        break;
                    case TipoDocumento.CUIL:
                        await newPage.SelectAsync("select#idtipodocreceptor", "96");
                        break;
                    case TipoDocumento.CUIT:
                        await newPage.SelectAsync("select#idtipodocreceptor", "96");
                        break;
                }

                var inputNroDocumento = await newPage.QuerySelectorAsync("#nrodocreceptor");
                if (inputNroDocumento != null)
                {
                    //Se ingresa la 
                    await inputNroDocumento.EvaluateFunctionAsync<dynamic>("(el, value) => el.value = value", NroDocumento);

                }

               

                string Forma = "#formadepago";
                string Numero = "1";
                switch (FormaPago)
                {
                    case CondicionVenta.Contado:
                        Numero = "1";
                        break;
                    case CondicionVenta.TarjetaDebito:
                        Numero = "2";
                        break;
                    case CondicionVenta.TarjetaCredito:
                        Numero = "3";
                        break;
   
                }
                var inputFormaPago = await newPage.QuerySelectorAsync(Forma + Numero);
                if (inputFormaPago != null)
                {
                    await inputFormaPago.ClickAsync();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("algo que no esta bien esta mal");
                }

                //se presona el boton siguiente para pasar al siguiente formulario
                var btnSiguiente3 = await newPage.QuerySelectorAsync("#formulario > input[type=button]:nth-child(4)");
                if (btnSiguiente3 != null)
                {
                    await btnSiguiente3.ClickAsync();
                }

                await newPage.WaitForNavigationAsync();

             

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                throw;
            }
        }

        //public async Task IngresarItems()
        //{
        //document.querySelector("#detalle_descripcion1")

        //}
        public void Cerrar()
        {
             this.browser.Dispose();
        }




    }
}
