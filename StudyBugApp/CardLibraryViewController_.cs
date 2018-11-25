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
    /// Page Navigation functionality with passing data between pages: Nandita Ghosh
    /// </summary>
    public partial class CardLibraryViewController : UIViewController
    {
        object guard = new object();
        string _pathToDatabase = Path.Combine("..", "sqlite2.db");

        public CardLibraryViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Updates View after loading in order to add navigation panel.
        /// Author: Nandita Ghosh
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
          //  NavigationController.SetHasNavigationBar(this, true);
            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
            viewMenu.Hidden = true;
        }

        /// <summary>
        /// Prepares for segue to pass card information to next view.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="segue">Segue.</param>
        /// <param name="sender">Sender.</param>
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "segueEditCard")
            {
                var editCard = segue.DestinationViewController as EditViewController;
                editCard.CardName = "General Knowledge";
                editCard.CardContent = "Test your general knowledge.";
            }
        }

        /// <summary>
        /// Click events for new card button which perform seque to navigate to New Card view.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="sender">Sender.</param>
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