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

        partial void NewCard_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("segueNewCard", this);
        }

        partial void BtnCard_1_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("sugueEditCard", this);
        }

        partial void BtnCard_2_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("sugueEditCard", this);
        }

        partial void BtnCard_3_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("sugueEditCard", this);
        }

        partial void BtnCard_4_TouchUpInside(UIButton sender)
        {
            this.PerformSegue("sugueEditCard", this);
        }
    }
}