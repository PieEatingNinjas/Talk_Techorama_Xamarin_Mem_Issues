using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;
using Ordina.Techorama.Memory.Droid.Helpers;

namespace Ordina.Techorama.Memory.Droid.Views.Custom
{
    public class CustomImageView : ImageView
    {
        public CustomImageView(Context context)
            : base(context)
        {
        }

        public CustomImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public CustomImageView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            //Do not draw when bitmap is recycled
            if ((Drawable as BitmapDrawable)?.Bitmap?.IsRecycled == true)
                return;

            base.OnDraw(canvas);
        }

        /// <summary>
        /// Load a drawable defined in a xml file instead of image file
        /// </summary>
        public void LoadCustomDrawable(int resId)
        {
            if (_disposed)
                return;

            base.SetImageResource(resId);
        }

        public override void SetImageResource(int resId)
        {
            if (_disposed)
                return;

            var image = BitmapFactory.DecodeResource(Application.Context.Resources, resId, new BitmapFactory.Options
            {
                InInputShareable = false,
                InPurgeable = false
            });

            var recycleDrawable = Drawable;

            Dispatcher.InvokeOnUIThread(() =>
            {
                try
                {
                    if (_disposed)
                        return;

                    SetImageBitmap(image);
                    ClearDrawable(recycleDrawable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CustomImageView.SetImageResource error: " + ex);
                }
            });
        }

        public void LoadFromLocalFile(string imagePath)
        {
            var image = BitmapFactory.DecodeFile(imagePath, new BitmapFactory.Options
            {
                InInputShareable = false,
                InPurgeable = false
            });

            var recycleDrawable = Drawable;

            Dispatcher.InvokeOnUIThread(() =>
            {
                try
                {
                    if (_disposed)
                        return;

                    SetImageBitmap(image);
                    ClearDrawable(recycleDrawable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CustomImageView.LoadFromLocalFile error: " + ex);
                }
            });
        }

        public void Clear()
        {
            try
            {
                if (Drawable != null)
                {
                    var drawable = Drawable;

                    SetImageBitmap(null);

                    ClearDrawable(drawable);
                    drawable = null;
                }
            }
            catch (ObjectDisposedException)
            {
                //Do nothing
            }
        }

        void ClearDrawable(Drawable drawable)
        {
            if (drawable != null)
            {
                if (drawable is BitmapDrawable)
                {
                    var bitmapDrawable = (BitmapDrawable)drawable;

                    var recycleBitmap = bitmapDrawable.Bitmap;
                    if (recycleBitmap != null && !recycleBitmap.IsRecycled)
                    {
                        recycleBitmap.Recycle();
                        recycleBitmap.Dispose();
                        recycleBitmap = null;
                    }
                }

                drawable.Dispose();
                drawable = null;
            }
        }

        bool _disposed;
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                Clear();
            }

            base.Dispose(disposing);
        }
    }
}
