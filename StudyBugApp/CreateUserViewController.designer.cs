// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace StudyBugApp
{
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