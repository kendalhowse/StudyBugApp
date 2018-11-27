using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// The edit card page which allows you to edit the selected card. But the functionality isn't set up or completed. 
    /// Page Design Author: Ahmed Mohammed
    /// Page Functionality: Nandita Ghosh
    /// </summary>
    public partial class StudyCubesViewController : UIViewController
    {
        public StudyCubesViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Updates View after loading in order to add navigation panel.
        /// Author: Nandita Ghosh
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
        }

        /// <summary>
        /// Toggle side menu panel.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }
    }
}