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
    [Register ("ShowCardListUITableViewController")]
    partial class ShowCardListUITableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ShowListTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ShowListTableView != null) {
                ShowListTableView.Dispose ();
                ShowListTableView = null;
            }
        }
    }
}