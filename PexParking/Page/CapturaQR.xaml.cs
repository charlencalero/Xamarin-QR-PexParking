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
                Labe_msj.Text = "";
                await Navigation.PushAsync(new ClienteCodigo(Parkeo));

            }
            catch (Exception ex)
            {
                await DisplayAlert("sistema", "El codigo leido no pertenece a PEX", "continuar");
                Labe_msj.Text = "";
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
