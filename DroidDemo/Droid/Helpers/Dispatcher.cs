using System;
using Android.OS;
using Java.Lang;

namespace Ordina.Techorama.Memory.Droid.Helpers
{
    public static class Dispatcher
    {
        public static void InvokeOnUIThread(Action action)
        {
            if (Thread.CurrentThread() == Looper.MainLooper.Thread)
            {
                action();
            }
            else
            {
                new Handler(Looper.MainLooper).Post(action);
            }
        }
    }
}
