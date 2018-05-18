using System;
using System.Collections.Generic;

using Xamarin.Forms;
using PexParking.Service;
namespace PexParking.Page
{
    public partial class CapturaQR : ContentPage
    {

        string Placa = "";
        string Celular = "";

        public CapturaQR()
        {
            InitializeComponent();
        }

        public CapturaQR(string placa,string celular)
        {
            InitializeComponent();
            scanservice = new ScanService();
            Placa = placa;
            Celular = celular;
        }

       async void Guardar_Clicked(object sender, System.EventArgs e)
        {

           

            if ( Labe_msj.Text=="ninguno")
                {
                await DisplayAlert("sistema", "No se capturo ningun codigo", "continuar");
                return;
            }


            try
            {
                string codigo = Labe_msj.Text;
                int valor = codigo.IndexOf("_");

                string piso = codigo.Substring(0, valor);
                string ubicacion = codigo.Substring(valor + 1, codigo.Length - valor - 1);

                var placa = "PLACA: "+Placa;
                var celular = Celular;
                var horalectura = DateTime.Now.ToString();
                var horaalerta = DateTime.Now.AddMinutes(45).ToString();

                //quitar -

                piso = piso.Replace("-", " ");
                var Parkeo = new Entity.parkeo(piso, ubicacion, placa, celular, horalectura, horaalerta,Labe_msj.Text,"","");
                // ABRIR LA OTRA VENTANA
                await Navigation.PushAsync(new ClienteCodigo(Parkeo));

            }
            catch (Exception ex)
            {
                await DisplayAlert("sistema", "El codigo Leido no pertenece a PEX", "continuar");
                return;
            }
           




        }

        int tapCount = 0;
        string msj;

        private ScanService scanservice;
        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            qrimage.IsVisible = false;
           qrimage.IsVisible = true;
            escaner("1");
        }

        private async void escaner(string tipo)
        {
           
          
            msj = await scanservice.ScannerQr();
            Labe_msj.Text = msj;
           
        //    ApiAsistencia(msj, tipo);


        }

        private async void ApiAsistencia(string dni, string tipo)
        {
            if (string.IsNullOrEmpty(dni))
            {
                await DisplayAlert("Error", "Ingresar un DNI", "Aceptar");
                return;
            }


            string result="";
            string url="";

            try
            {

                string fecha;
                string hora;

                fecha = DateTime.Now.ToString("yyyy-MM-dd");
                hora = DateTime.Now.ToString("hh:mm:ss");

                //HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(Constantes.RestUrl);
                //url = string.Format(Constantes.CarpUrl + "/asistencia/CRUD_Ctrl_asistencia.php?tipo=4&origen=2&textdni={0}&turn_codi={1}&fecha={2}&hora={3}&usua_codigo=1", dni, tipo, fecha, hora);

                //var response = await client.GetAsync(url);
                //result = response.Content.ReadAsStringAsync().Result;

            }

           

            catch (Exception ex)
            {
                await DisplayAlert("System", "Se perdio la conexion, " + ex.Message, "Aceptar");
                return;
            }

            Labe_msj.Text = msj;


            //if (string.IsNullOrEmpty(result) || result == "null")
            //{
            //    await DisplayAlert("System", "Error al registrar asistencia", "Aceptar");

            //    return;
            //}

            //mensaje msj;

            //try
            //{

            //    msj = JsonConvert.DeserializeObject<mensaje>(result);

            //    if (msj.tipo == "1")
            //    {
            //        Labe_msj.TextColor = Color.Red;
            //        Labe_msj.Text = msj.Mensaje;
            //    }
            //    else
            //    {
            //        Labe_msj.TextColor = Color.Blue;
            //        Labe_msj.Text = msj.Mensaje;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    await DisplayAlert("System", ex.Message + " - " + url, "ok");
            //    msj = null;
            //}
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            escaner("5");
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            escaner("2");
        }
    }
}
