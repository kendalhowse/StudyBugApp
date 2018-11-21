using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    public partial class CardLibraryViewController : UIViewController
    {
        public CardLibraryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
            viewMenu.Hidden = true;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "segueEditCard")
            {
                var editCard = segue.DestinationViewController as EditViewController;
                editCard.CardName = "General Knowledge";
                editCard.CardContent = "Test your general knowledge.";
            }
        }

        partial void NewCard_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueNewCard", this);
        }

        partial void BtnCard_1_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueEditCard", this);
        }

        partial void BtnCard_2_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueEditCard", this);
        }

        partial void BtnCard_3_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueEditCard", this);
        }

        partial void BtnCard_4_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueEditCard", this);
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }
    }
}