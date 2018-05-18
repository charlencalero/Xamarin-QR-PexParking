using PexParking.Page;
using Xamarin.Forms;

namespace PexParking
{
    public partial class PexParkingPage : ContentPage
    {
        public PexParkingPage()
        {
            InitializeComponent();
        }

        async void Ingre_Clicked(object sender, System.EventArgs e)
        {
          
            if (Text_Placa.Text== null)
            {
                await DisplayAlert("system", "Ingrese una Placa Valida", "continuar");
                return;
            }
            if (Text_Celular.Text ==null)
            {
                await DisplayAlert("system", "Ingrese una Celular Valido", "continuar");
                return;
            }

            if (Text_Placa.Text.Length != 6 )
            {
                await DisplayAlert("system", "Ingrese una Placa Valida", "continuar");
                return;
            }
            if (Text_Celular.Text.Length != 9)
            {
                await DisplayAlert("system", "Ingrese una Celular Valido", "continuar");
                return;
            }

            await Navigation.PushAsync(new CapturaQR(Text_Placa.Text.ToUpper(),Text_Celular.Text));
        }
    }
}
