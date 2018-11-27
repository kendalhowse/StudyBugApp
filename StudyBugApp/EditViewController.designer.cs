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
    [Register ("EditViewController")]
    partial class EditViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView txtCardContent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCardName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMenu { get; set; }

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnMenu != null) {
                btnMenu.Dispose ();
                btnMenu = null;
            }

            if (txtCardContent != null) {
                txtCardContent.Dispose ();
                txtCardContent = null;
            }

            if (txtCardName != null) {
                txtCardName.Dispose ();
                txtCardName = null;
            }

            if (viewMenu != null) {
                viewMenu.Dispose ();
                viewMenu = null;
            }
        }
    }
}