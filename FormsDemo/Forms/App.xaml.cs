using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ordina.Techorama.Memory.XamForms.Pages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Ordina.Techorama.Memory.XamForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
