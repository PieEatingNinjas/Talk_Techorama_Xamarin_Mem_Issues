using System;

using Xamarin.Forms;

namespace Ordina.Techorama.Memory.XamForms.Helpers
{
    public static class ImageHelper
    {
        public static ImageSource GetImage(string imageName)
        {
            return ImageSource.FromResource(typeof(App).Namespace + ".Resources." + imageName);
        }
    }
}

