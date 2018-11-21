using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;

namespace StudyBugApp
{
    public partial class DashboardViewController : UIViewController
    {
        public string Name { get; set;  }
        public string ProfilePicture { get; set; }

        public DashboardViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            // The name value needs to be retrieved from the database instead of passed from login page. Passing from login page interferes with the
            // sign up button functionality. It would also be better to have first name instead of the email displayed.
            base.ViewDidLoad();
            NavigationController.NavigationBarHidden = false;

            // uses the Facebook Users profile
            if (!String.IsNullOrEmpty(ProfilePicture))
            {
                imgProfile.Image = UIImageFromUrl(ProfilePicture);
                imgMenu.Image = UIImageFromUrl(ProfilePicture);
            }
            

            NavigationItem.RightBarButtonItem = btnMenu;
            lblWelcome.Text = string.Format("Welcome {0}!", Name);
            viewMenu.Hidden = true;
            lbLastPlayed.Text = DateTime.Now.ToString("MMM dd, yyyy");
            lbLastScore.Text = "215";
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }

        partial void BtnCardLibrary_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueCardLibrary", this);
        }

        partial void BtnLogout_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueDbToLogin", this);
        }

        /// <summary>
        /// Used to get a UIImage from a url
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static UIImage UIImageFromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }
}