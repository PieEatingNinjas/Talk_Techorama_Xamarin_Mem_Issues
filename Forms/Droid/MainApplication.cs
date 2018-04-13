using System;
using Android.App;
using Android.Runtime;

namespace Ordina.Techorama.Memory.XamForms.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();

            Console.WriteLine("WARNING: low memory detected");
        }
    }
}
