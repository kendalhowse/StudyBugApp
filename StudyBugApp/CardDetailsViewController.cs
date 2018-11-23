using Foundation;
using System;
using UIKit;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace StudyBugApp
{
    public partial class CardDetailsViewController : UIViewController
    {

        private Card selectedCard;
        object guard = new object();
        private string _pathToDatabase;


        public CardDetailsViewController (IntPtr handle) : base (handle)
        {
        }
        public CardDetailsViewController()
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _pathToDatabase = Path.Combine("..", "sqlite2.db");
            UpdateContent();
        }
        internal int SelectedCardID
        {
            get;
            set;
        }


        public void UpdateContent()
        {
            SelectCard(SelectedCardID+1);
            Console.WriteLine(SelectedCardID);
            Card card = selectedCard;
            string qtxt = card.Question;
            questionF.Text = qtxt;
            string atxt = card.Answer;
            answerF.Text = atxt;
        }

        public void SelectCard(int id)
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);

            //card.ID = ID;
            //card.Question = Question;
            //card.Answer = Answer;
            //card.Topic = Topic;
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
                foreach (Card p in cardList)
                {
                    if (p.ID == id)
                    {
                        selectedCard = p;
                    }
                }
            }



            db.Close();
        }

    }
}