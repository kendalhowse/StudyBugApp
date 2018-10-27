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
    [Register ("ViewController")]
    partial class LoginScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogIn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton createNewUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton facebookLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel signInWithFacebook { get; set; }

        [Action ("BtnLogIn_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnLogIn_TouchUpInside (UIKit.UIButton sender);

        [Action ("FacebookLogin_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FacebookLogin_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnLogIn != null) {
                btnLogIn.Dispose ();
                btnLogIn = null;
            }

            if (createNewUser != null) {
                createNewUser.Dispose ();
                createNewUser = null;
            }

            if (emailField != null) {
                emailField.Dispose ();
                emailField = null;
            }

            if (facebookLogin != null) {
                facebookLogin.Dispose ();
                facebookLogin = null;
            }

            if (passwordField != null) {
                passwordField.Dispose ();
                passwordField = null;
            }

            if (signInWithFacebook != null) {
                signInWithFacebook.Dispose ();
                signInWithFacebook = null;
            }
        }
    }
}