using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Ordina.Techorama.Memory.XamForms.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override void ReceiveMemoryWarning(UIApplication application)
        {
            base.ReceiveMemoryWarning(application);

            Console.WriteLine("WARNING: low memory detected");
        }
    }
}
