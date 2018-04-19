using System;
using CoreGraphics;
using UIKit;

namespace Ordina.Techorama_2018.Memory.iOS.ViewControllers
{
    public class MainViewController : UIViewController
    {
        UIButton _galleryButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Main";

            var mainView = new UIView
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.White
            };
            View = mainView;

            _galleryButton = new UIButton
            {
                Frame = new CGRect(mainView.Frame.Width / 2 - 100, 120, 200, 44)
            };
            _galleryButton.SetTitle("Go to gallery", UIControlState.Normal);
            _galleryButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);

            _galleryButton.TouchUpInside += GalleryButton_TouchUpInside;

            mainView.AddSubview(_galleryButton);
        }

        void GalleryButton_TouchUpInside(object sender, EventArgs e)
        {
            NavigationController.PushViewController(new GalleryViewController(), true);
        }

        bool _disposed;
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                _galleryButton.TouchUpInside -= GalleryButton_TouchUpInside;
            }

            base.Dispose(disposing);
        }
    }
}
