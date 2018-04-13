using System;
using Ordina.Techorama.Memory.XamForms.Helpers;
using Xamarin.Forms;

namespace Ordina.Techorama.Memory.XamForms.Pages
{
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            for (int i = 0; i < 50; i++)
            {
                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    Aspect = Aspect.Fill,
                    Margin = new Thickness(0, 20, 0, 10),
                    Source = ImageHelper.GetImage("xamarin.png")
                };

                ImageContainer.Children.Add(image);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NextButton.Clicked += Next_Clicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            NextButton.Clicked -= Next_Clicked;
        }

        async void Next_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage());
        }
    }
}
