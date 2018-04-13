using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Ordina.Techorama_2018.Memory.Droid;

namespace Ordina.Techorama.Memory.Droid.Views.Activities
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityMain);
        }
    }
}

