using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    public partial class LoginScreen : UIViewController
    {
        public LoginScreen (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BtnLogIn_TouchUpInside(UIButton sender)
        {
            if (!IsValidCredential())
            {
                new UIAlertView("Error",
                                "Username and password mismatched.",
                                null,
                                "OK",
                                null).Show();
            } else {
                this.PerformSegue("Push", this);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var dashboard = segue.DestinationViewController as DashboardViewController;
            dashboard.Name = emailField.Text;
        }

        private bool IsValidCredential()
        {
            if (String.IsNullOrEmpty(emailField.Text.Trim()) ||
               String.IsNullOrEmpty(passwordField.Text.Trim()))
                return false;

            return true; // replace it with login validation
        }
    }
}