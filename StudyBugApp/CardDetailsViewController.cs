using Foundation;
using System;
using UIKit;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace StudyBugApp
{/// <summary>
/// Author: Ahmed Mohammed
/// show the details of card selected from list of cards
/// </summary>
    public partial class CardDetailsViewController : UIViewController
    {
        // field to store card to be shown in this screen
        private Card selectedCard;
        //guard ojbec to lock thread during database access
        object guard = new object();
        //path to database
        private string _pathToDatabase;

        
        public CardDetailsViewController (IntPtr handle) : base (handle)
        {
        }
        //defualt constructor
        public CardDetailsViewController()
        {

        }
        //method called on load page done
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _pathToDatabase = Path.Combine("..", "sqlite2.db");
            //update content of page with the selected card from list of cards
            UpdateContent();
        }
        /// <summary>
        /// author : Ahmed
        /// set get, selected card ID number
        /// </summary>
        internal int SelectedCardID
        {
            get;
            set;
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// To update content on selected card from card list
        /// </summary>
        public void UpdateContent()
        {   // take selected row id number from prvious screen and set the selected card to be shown here
            SelectCard(SelectedCardID+1);
            //set selected card to a new card object
            Card card = selectedCard;
            //retrive the question fro selectecd card
            string qtxt = card.Question;
            //show question
            questionF.Text = qtxt;
            //retrieve answer for selected card 
            string atxt = card.Answer;
            // show selected answer here
            answerF.Text = atxt;
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// retrieve card from database base on id of card selected in the list view (table view controller)
        /// </summary>
        /// <param name="id"></param>
        public void SelectCard(int id)
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);

            lock (guard)
            {
                db.CreateTable<Card>();
            }


            List<Card> cardList;

            lock (guard)
            {
                cardList = db.Table<Card>().ToList();
            }

            if (cardList.Count == 0)
            {
                var errorAlertController = UIAlertController.Create("Error", "there is no cards in library.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);

            }
            else
            {
                //go through the list to take the card with the id passed from list view
                foreach (Card p in cardList)
                {
                    //if id is what is selected in the list then set card 
                    if (p.ID == id)
                    {
                        selectedCard = p;
                    }
                }
            }



            db.Close();
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// Back button to dismiss current card detail screen an go back to list view
        /// 
        /// </summary>
        /// <param name="sender"></param>
        partial void BackBtn_TouchUpInside(UIButton sender)
        {
            this.DismissViewController(true, null);
        }
    }
}