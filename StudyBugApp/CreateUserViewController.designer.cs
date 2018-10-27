using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// Declares objects for the UI of the screen.
    /// Kendal Howse
    /// </summary>
    [Register ("CreateUserViewController")]
    partial class CreateUserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField confirmPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField email { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField firstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField password { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signUp { get; set; }

        [Action ("SignUp_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SignUp_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (confirmPassword != null) {
                confirmPassword.Dispose ();
                confirmPassword = null;
            }

            if (email != null) {
                email.Dispose ();
                email = null;
            }

            if (firstName != null) {
                firstName.Dispose ();
                firstName = null;
            }

            if (lastName != null) {
                lastName.Dispose ();
                lastName = null;
            }

            if (password != null) {
                password.Dispose ();
                password = null;
            }

            if (signUp != null) {
                signUp.Dispose ();
                signUp = null;
            }
        }
    }
}