using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// The edit card page which allows you to edit the selected card. But the functionality isn't set up or completed. 
    /// Page Design Author: Nisini Dias
    /// </summary>
    public partial class EditViewController : UIViewController
    {
        public string CardName { get; set; }
        public string CardContent { get; set; }

        public EditViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
            viewMenu.Hidden = true;

            txtCardName.Text = CardName;
            txtCardContent.Text = CardContent;
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }
    }
}