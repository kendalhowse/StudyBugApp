using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// Dashboard view which shows user profile with most recent game data.
    /// Page Design Author: Nandita Ghosh
    /// Page Functionality Author: Nandita Ghosh and Kendal Howse
    /// </summary>
    public partial class DashboardViewController : UIViewController
    {
        public string Name { get; set;  }
        public string ProfilePicture { get; set; }

        public DashboardViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Updates View after loading in order to add navigation panel and user profile info.
        /// Author: Nandita Ghosh and Kendal Howse
        /// </summary>
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

        /// <summary>
        /// Toggle side menu panel.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }

        /// <summary>
        /// Click events for Card Library from menu which perform seque to navigate to Card Library view.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnCardLibrary_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueCardLibrary", this);
        }

        /// <summary>
        /// Click events for Log Out from menu which perform seque to navigate to Log In view.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnLogout_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueDbToLogin", this);
        }

        /// <summary>
        /// Used to get a UIImage from a url
        /// Author: Kendal Howse
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