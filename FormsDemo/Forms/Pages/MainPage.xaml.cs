using Xamarin.Forms;
using System;

namespace Ordina.Techorama.Memory.XamForms.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Images_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage());
        }
    }
}
