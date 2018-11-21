using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    public partial class StudyCubesViewController : UIViewController
    {
        public StudyCubesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }
    }
}