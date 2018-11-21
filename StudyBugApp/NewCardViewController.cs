using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    public partial class NewCardViewController : UIViewController
    {
        public NewCardViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
            viewMenu.Hidden = true;
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }
    }
}