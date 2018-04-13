using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace Ordina.Techorama.Memory.Droid.Views.Activities
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button _imageButton;
        Button _customImageButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityMain);

            _imageButton = FindViewById<Button>(Resource.Id.ActivityMain_Button_Image);
            _customImageButton = FindViewById<Button>(Resource.Id.ActivityMain_Button_CustomImage);

            _imageButton.Click += Button_Click;
            _customImageButton.Click += Button_Click;
        }


        void Button_Click(object sender, EventArgs e)
        {
            var intent = ImageActivity.CreateIntent(this, sender == _customImageButton);

            StartActivity(intent);
        }

        bool _disposed;
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                _imageButton.Click -= Button_Click;
                _customImageButton.Click -= Button_Click;
            }

            base.Dispose(disposing);
        }
    }
}

