using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// The Dashboard screen for the Card Library, Connects to new card page and the edit card page.
    /// Page Design Author: Nisini Dias,
    /// Page functionality Author: Ahmed Mohammed
    /// </summary>
    public partial class CardLibraryViewController : UIViewController
    {
        object guard = new object();
        private string _pathToDatabase;

        public CardLibraryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _pathToDatabase = Path.Combine("..", "sqlite2.db");
          //  NavigationController.SetHasNavigationBar(this, true);
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

        

        public void GetAllCard()
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);
            List<Card> cards;
            lock (guard)
            {
                db.CreateTable<Card>();
            }
            lock (guard)
            {
                cards = db.Table<Card>().ToList();
            }

            if (cards.Count == 0)
            {
                var errorAlertController = UIAlertController.Create("Error", "there is no cards in library.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);

            }

            db.Close();

        }

        partial void UIButton99633_TouchUpInside(UIButton sender)
        {
            GetAllCard();
            this.DismissViewController(true, null);
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }




    }
}