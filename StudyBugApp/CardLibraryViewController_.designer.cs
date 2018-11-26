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
        UIKit.UIBarButtonItem btnMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton newCard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton showAllCardBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMenu { get; set; }

        [Action ("BtnMenu_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnMenu_Activated (UIKit.UIBarButtonItem sender);

        [Action ("NewCard_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NewCard_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton99633_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton99633_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnMenu != null) {
                btnMenu.Dispose ();
                btnMenu = null;
            }

            if (newCard != null) {
                newCard.Dispose ();
                newCard = null;
            }

            if (showAllCardBtn != null) {
                showAllCardBtn.Dispose ();
                showAllCardBtn = null;
            }

            if (viewMenu != null) {
                viewMenu.Dispose ();
                viewMenu = null;
            }
        }
    }
}