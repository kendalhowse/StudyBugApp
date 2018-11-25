using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// The edit card page which allows you to edit the selected card. But the functionality isn't set up or completed. 
    /// Page Design Author: Nisini Dias
    /// Page Functionality: Nandita Ghosh
    /// </summary>
    public partial class EditViewController : UIViewController
    {
        public string CardName { get; set; }
        public string CardContent { get; set; }

        public EditViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Updates View after loading in order to add navigation panel and card info.
        /// Author: Nandita Ghosh
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
            viewMenu.Hidden = true;

            txtCardName.Text = CardName;
            txtCardContent.Text = CardContent;
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