using System;
using Android.App;
using Android.Runtime;

namespace Ordina.Techorama.Memory.Droid
{
    [Application(Theme = "@style/ApplicationBaseTheme")]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();

            Console.WriteLine("WARNING: low memory detected");
        }
    }
}
