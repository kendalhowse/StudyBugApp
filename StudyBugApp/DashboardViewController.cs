using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    public partial class DashboardViewController : UIViewController
    {
        public string Name { get; set;  }
        public DashboardViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //btnMenu.Image = UIImage.FromFile("menu.png");
            NavigationItem.RightBarButtonItem = btnMenu;
            lblWelcome.Text = string.Format("Welcome {0}!", Name);
            viewMenu.Hidden = true;
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }
    }
}