using CoreGraphics;
using UIKit;

namespace Ordina.Techorama_2018.Memory.iOS.ViewControllers
{
    public class MainViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Main";

            var mainView = new UIView
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.White
            };

            var firstButton = new UIButton
            {
                Frame = new CGRect(mainView.Frame.Width / 2 - 100, 120, 200, 44)
            };
            firstButton.SetTitle("Go to gallery", UIControlState.Normal);
            firstButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            mainView.AddSubview(firstButton);

            View = mainView;
        }
    }
}
