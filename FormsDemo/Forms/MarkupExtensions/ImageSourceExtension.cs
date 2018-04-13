using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Ordina.Techorama.Memory.XamForms.Helpers;

namespace Ordina.Techorama.Memory.XamForms.MarkupExtensions
{
    [ContentProperty(nameof(Name))]
    public class ImageSourceExtension : IMarkupExtension
    {
        public string Name { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Name))
                return null;

            return ImageHelper.GetImage(Name);
        }
    }
}
