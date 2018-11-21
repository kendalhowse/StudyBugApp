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
    [Register ("GameLaunchViewController")]
    partial class GameLaunchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Exit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView Game { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartGame { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Exit != null) {
                Exit.Dispose ();
                Exit = null;
            }

            if (Game != null) {
                Game.Dispose ();
                Game = null;
            }

            if (StartGame != null) {
                StartGame.Dispose ();
                StartGame = null;
            }
        }
    }
}