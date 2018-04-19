using UIKit;
using System.Collections.Generic;

namespace Ordina.Techorama_2018.Memory.iOS.ViewControllers
{
    public class GalleryViewController : UIViewController
    {
        List<string> _images;
        int _currentImageIndex;

        ImageViewController _imageViewController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Gallery";

            var mainView = new UIView
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.White
            };
            View = mainView;

            _imageViewController = new ImageViewController(this);
            AddChildViewController(_imageViewController);
            mainView.AddSubview(_imageViewController.View);
            _imageViewController.DidMoveToParentViewController(this);

            _currentImageIndex = 0;
            _images = new List<string>
            {
                "Xamarin",
                "Ordina",
                "Microsoft",
                "Os"
            };

            ShowNextImage();
        }

        public void ShowNextImage()
        {
            _imageViewController.LoadImage(_images[_currentImageIndex]);

            _currentImageIndex++;

            if (_currentImageIndex >= _images.Count)
                _currentImageIndex = 0;
        }
    }
}
