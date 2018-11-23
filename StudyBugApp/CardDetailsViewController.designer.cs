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
    [Register ("CardDetailsViewController")]
    partial class CardDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView answerF { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView questionF { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (answerF != null) {
                answerF.Dispose ();
                answerF = null;
            }

            if (questionF != null) {
                questionF.Dispose ();
                questionF = null;
            }
        }
    }
}