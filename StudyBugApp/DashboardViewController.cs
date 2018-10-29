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
            // The name value needs to be retrieved from the database instead of passed from login page. Passing from login page interferes with the
            // sign up button functionality. It would also be better to have first name instead of the email displayed.
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