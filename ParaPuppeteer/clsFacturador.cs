using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace ParaPuppeteer
{
    class clsFacturador
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
        #endregion

        #region "Funciones"
        public async Task DescargarNavegador()
        {

            BrowserFetcher browserFetcher = new BrowserFetcher(new BrowserFetcherOptions
            {
                Path = this.Path
            });


            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);

            this.Options = new LaunchOptions
            {
                //Args = ...,
                Headless = false,
                ExecutablePath = browserFetcher.GetExecutablePath(BrowserFetcher.DefaultRevision),
                DefaultViewport = null,
                Timeout = 10000
            };


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

                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw new Exception("No se pudo abrir el navegador", ex);

            }


        }

        //funcion donde se hace login en la pagina de AFIP
        public async Task Ingreso()
        {
            await Page.GoToAsync(this.URL);
            var btnIngr = await Page.QuerySelectorAsync(""); ///buscar algo para esperar
            if (btnIngr != null)
            {
                //se ingresa el cuil luego se presiona el boton enter
                await Page.Keyboard.TypeAsync(this.CUIL);
                await Page.Keyboard.PressAsync("Enter");
                Response respuesta = await Page.WaitForNavigationAsync();
                if (respuesta.Ok)
                {
                    //se ingresa luego la constraseña y luego se presiona la tecla enter
                    await Page.Keyboard.TypeAsync(this.Password);
                    await Page.Keyboard.PressAsync("Enter");
                    await Page.WaitForNavigationAsync();

                    await Page.WaitForTimeoutAsync(8000);
                }
                else
                {
                    throw new Exception("La pagina no ha cargado correectamente");
                }
            }
            else
            {
                //algun error
            }
            

        }

        //funcion que llega a la pagina de comprobantes en linea de AFIP
        public async Task IrAComprobantesEnLinea()
        {
            //Se selecciona el boton de comprobantes en linea
            await Page.WaitForSelectorAsync("#root > div > main > section:nth-child(3) > div > div:nth-child(3) > div.col-xs-12.col-md-5.col-sm-5.col-lg-5 > div.panel.panel-default.p-a-2.m-t-1 > div:nth-child(2) > div > div.media-left.small.text-center > i");
            var btnComprantes = await Page.QuerySelectorAsync("#root > div > main > section:nth-child(3) > div > div:nth-child(3) > div.col-xs-12.col-md-5.col-sm-5.col-lg-5 > div.panel.panel-default.p-a-2.m-t-1 > div:nth-child(2) > div > div.media-left.small.text-center > i");
            if (btnComprantes != null)
            {
                await btnComprantes.ClickAsync();

            }
            else
            {
                throw new Exception("No se detecta el boton de comprobantes en linea");
            }

            await Page.WaitForTimeoutAsync(4000);

            //para evitar errores, se busca la pestaña de comprobantes en linea por la url
            var pestanas = Browser.Targets();
            foreach (var pes in pestanas)
            {
                Console.WriteLine(pes.Url);
                if (pes.Url.Length >= URLComprobantes.Length)
                {

                    if (pes.Url.Substring(0, URLComprobantes.Length).Equals(URLComprobantes))
                    {
                        //se selecciona la pestaña de comprobantes en linea y se la guarda en la variable NewPage
                        NewPage = await pes.PageAsync();
                    }
                    else
                    {
                        throw new Exception("No se encuentra la pagina " + URLComprobantes);
                    }
                }
            }

            
            //se espera a que la pagina navegue
            await NewPage.WaitForTimeoutAsync(3000);
            //
            //
            //Se selecciona la empresa ### esto hay que cambiarlo dado que el usuario puede tener mas de un domicilio fiscal
            var btnEmpresa = await NewPage.QuerySelectorAsync("#contenido > form > table > tbody > tr:nth-child(4) > td > input.btn_empresa.ui-button.ui-widget.ui-state-default.ui-corner-all");

            if (btnEmpresa != null)
            {
                await btnEmpresa.ClickAsync();
            }
            else
            {
                throw new Exception("No se ha encotrado el domicilio fiscal");
            }

            await NewPage.WaitForNavigationAsync();



        }
        #endregion
    }
}
