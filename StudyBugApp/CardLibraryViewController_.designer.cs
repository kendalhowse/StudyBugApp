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
    [Register ("CardLibraryViewController")]
    partial class CardLibraryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCard_1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCard_2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCard_3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCard_4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton newCard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMenu { get; set; }

        [Action ("BtnCard_1_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCard_1_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnCard_2_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCard_2_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnCard_3_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCard_3_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnCard_4_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnCard_4_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        [Action ("NewCard_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NewCard_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCard_1 != null) {
                btnCard_1.Dispose ();
                btnCard_1 = null;
            }

            if (btnCard_2 != null) {
                btnCard_2.Dispose ();
                btnCard_2 = null;
            }

            if (btnCard_3 != null) {
                btnCard_3.Dispose ();
                btnCard_3 = null;
            }

            if (btnCard_4 != null) {
                btnCard_4.Dispose ();
                btnCard_4 = null;
            }

            if (btnMenu != null) {
                btnMenu.Dispose ();
                btnMenu = null;
            }

            if (newCard != null) {
                newCard.Dispose ();
                newCard = null;
            }

            if (viewMenu != null) {
                viewMenu.Dispose ();
                viewMenu = null;
            }
        }
    }
}