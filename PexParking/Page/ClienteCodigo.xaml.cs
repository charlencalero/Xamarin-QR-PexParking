using System;
using System.Collections.Generic;
using PexParking.Entity;
using Xamarin.Forms;

namespace PexParking.Page
{
    public partial class ClienteCodigo : ContentPage
    {
        parkeo parkeo_cliente = new parkeo();

        async void Nuevo_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CapturaQR(parkeo_cliente.placa, parkeo_cliente.celular));
        }


        int MIN_SCALE = 1;
        int MAX_SCALE = 4;

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (Content.Scale > MIN_SCALE)
            {
                RestoreScaleValues();
            }
            else
            {
                Content.AnchorX = Content.AnchorY = 0.5;
                Content.ScaleTo(MAX_SCALE, 250, Easing.CubicInOut);
            }
        }

        void RestoreScaleValues()
        {
            Content.ScaleTo(MIN_SCALE, 250, Easing.CubicInOut);
            Content.TranslateTo(0.5, 0.5, 250, Easing.CubicInOut);

           // currentScale = 1;

            Content.TranslationX = 0.5;
            Content.TranslationY = 0.5;

           //plano. xOffset = Content.TranslationX;
          //  yOffset = Content.TranslationY;
        }

        void verimagen_Clicked(object sender, System.EventArgs e)
        {
            botonplano.IsVisible = false;

            if(plano.IsVisible==true)
            {
                plano.IsVisible = false; 
            }
            else
            {
                plano.IsVisible = true;
                plano.Source = parkeo_cliente.imagen;
            }

            botonplano.IsVisible = true;

        }


        public ClienteCodigo()
        { 
            InitializeComponent();
        }
            
        public ClienteCodigo(parkeo Parkeo)
        {
            InitializeComponent();

            parkeo_cliente = Parkeo;

           

            //
            List<estacionamiento> esta = new List<estacionamiento>();


            esta.Add(new estacionamiento("PISO-04_102", "102", "43", "4", "pa4.png"));
            esta.Add(new estacionamiento("PISO-02_057", "57", "22", "2", "pa2.png"));
            esta.Add(new estacionamiento("PISO-01_99", "99", "18", "1", "pa1.png"));
            esta.Add(new estacionamiento("PISO-03_105", "105", "35", "3", "pa3.png"));

            int index = 0;

            for (int i = 0; i < esta.Count; i++)
            {
                if( esta[i].codigo==Parkeo.codigo )
                {
                    index =i; 
                }

            
            }


            labepiso.Text = Parkeo.piso;
            labeubicacion.Text = Parkeo.ubicacion;
            labeplaca.Text = Parkeo.placa;
            labehoraactu.Text = Parkeo.horalectura;
            labehoraalarm.Text = Parkeo.horaalerta;

            parkeo_cliente.pasillo ="Su pasillo es el Nro: " +esta[index].pasillo;

            labepasillo.Text = parkeo_cliente.pasillo;
            parkeo_cliente.imagen = esta[index].imagen;

        }
    }
}
