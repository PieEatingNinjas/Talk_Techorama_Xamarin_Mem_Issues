using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using Ordina.Techorama.Memory.Droid.Views.Custom;
using Android.Views;
using System;

namespace Ordina.Techorama.Memory.Droid.Views.Activities
{
    [Activity]
    public class ImageActivity : AppCompatActivity
    {
        const string UseCustomImageviewKey = "UseCustomImageviewKey";

        LinearLayout _imageContainer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityImage);

            _imageContainer = FindViewById<LinearLayout>(Resource.Id.ActivityImage_LinearLayout_ImageContainer);

            var useCustomImageViews = false;

            if (Intent?.HasExtra(UseCustomImageviewKey) == true)
                useCustomImageViews = Intent.GetBooleanExtra(UseCustomImageviewKey, false);

            for (int i = 0; i < 5; i++)
            {
                ImageView imageView = null;

                if (useCustomImageViews)
                    imageView = new CustomImageView(this);
                else
                    imageView = new ImageView(this);

                imageView.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent)
                {
                    Gravity = GravityFlags.CenterHorizontal,
                    TopMargin = 20,
                    LeftMargin = 20,
                    RightMargin = 20
                };

                imageView.SetScaleType(ImageView.ScaleType.FitXy);

                var resId = 0;

                switch (i)
                {
                    case 0:
                        resId = Resource.Drawable.Techorama;
                        break;
                    case 1:
                        resId = Resource.Drawable.Xamarin;
                        break;
                    case 2:
                        resId = Resource.Drawable.Os;
                        break;
                    case 3:
                        resId = Resource.Drawable.Ordina;
                        break;
                    case 4:
                        resId = Resource.Drawable.Microsoft;
                        break;
                }

                imageView.SetImageResource(resId);

                _imageContainer.AddView(imageView);
            }
        }

        public static Intent CreateIntent(Context context, bool useCustomImageView)
        {
            var intent = new Intent(context, typeof(ImageActivity));

            intent.PutExtra(UseCustomImageviewKey, useCustomImageView);

            return intent;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            Dispose();
        }

        bool _disposed;
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (_imageContainer?.ChildCount > 0)
                {
                    for (int i = _imageContainer.ChildCount - 1; i >= 0; i--)
                    {
                        var view = _imageContainer.GetChildAt(i);

                        if (view is ImageView imageView)
                        {
                            _imageContainer.RemoveView(imageView);

                            imageView.Dispose();
                            imageView = null;
                        }
                    }
                }

                _imageContainer = null;

                //This is here just to prove that with normal imageviews the drawables are not disposed correctly
                GC.Collect();
            }

            base.Dispose(disposing);
        }
    }
}
