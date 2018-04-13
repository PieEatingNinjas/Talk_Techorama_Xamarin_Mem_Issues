using PropertyChanged;
using System;

namespace Ordina.Techorama.Memory.XamForms.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SubscribedEventsViewModel : BaseViewModel
    {
        public Object Page { get; set; }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

