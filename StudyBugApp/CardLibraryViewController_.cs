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
    /// Page functionality and passing data between pages (Show All Cards) Author: Ahmed Mohammed
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

        
        /// <summary>
        /// Author: Ahmed Mohammed
        /// Get All cards from database 
        /// </summary>
        public void GetAllCard()
        {
            //start connection to database
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);
            // create list to store data
            List<Card> cards;
            lock (guard)
            {
                // create table if not exist to avoid sqlite error
                db.CreateTable<Card>();
            }
            lock (guard)
            {
                // retireve all tables records to list
                cards = db.Table<Card>().ToList();
            }
                //check if retrieved list is empty
            if (cards.Count == 0)
            {
                //show error there is no cards yet
                var errorAlertController = UIAlertController.Create("Error", "there is no cards in library.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);

            }
            //close database connection
            db.Close();

        }
        /// <summary>
        /// Author Ahmed Mohammed
        /// retrive all cards and dismiss current view to go
        /// </summary>
        /// <param name="sender"></param>
        partial void UIButton99633_TouchUpInside(UIButton sender)
        {
            // get all cards
            GetAllCard();
            //get this screen and send data to other screen and dismess current button
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