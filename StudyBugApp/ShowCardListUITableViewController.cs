using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;
using SQLite;
using System.Linq;

namespace StudyBugApp
{
    public partial class ShowCardListUITableViewController : UITableViewController

    {
        CardListTableViewSource tableSource;
        List<Card> cards;
        private List<string> topics;
        private List<string> distTopics;
        List<string> Questions;
        List<string> Answers;
        Card selectedCard;

        

        object guard = new object();
        private string _pathToDatabase;

        

        public ShowCardListUITableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
          
            _pathToDatabase = Path.Combine("..", "sqlite2.db");
            //load list of all items from table
            GetAllCard();
            GetAllTopics();
            //List<string> to = new List<string>();
            //to.Add("ahmed");
            //to.Add("ahmed");
            //to.Add("ahmed");
            tableSource = new CardListTableViewSource(topics, this);
            ShowListTableView.Source = tableSource;
            tableSource.NewPageEvent += HandleNewPage;
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    if (segue.Identifier == "CardDetailsSeque")
        //    {
        //        var cardDetailsViewController = segue.DestinationViewController as CardDetailsViewController;
        //        if (cardDetailsViewController != null)
        //        {
        //            var source = ShowListTableView.Source as CardListTableViewSource;
        //            var rowPath = ShowListTableView.IndexPathForSelectedRow;
        //            int itemNumber = source.SelectedRowId(rowPath.Row); //GetItem(rowPath.Row);
        //           // SelectCard(itemNumber);
        //            cardDetailsViewController.SelectedCardID = itemNumber;
        //        }

        //    }
        // }



    

        public void HandleNewPage(object sender, EventArgs e)
        {
            this.NavigationController.PushViewController(new CardDetailsViewController(), true);
        }

        public void GetAllCard()
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);

            //lock (guard)
            //{
            //    db.CreateTable<Card>();
            //}
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

        public void GetAllTopics()
        {
           
            topics = new List<string>();
            foreach (var p in cards)
            {
                string str = p.Topic;
                topics.Add(str);
            }
            distTopics = cards.Select(x => x.Topic).Distinct().ToList();
        }

        public void GetAllQuestions()
        {
            foreach (Card p in cards)
            {
                topics.Add(p.Question);
            }
        }

        public void GetAllAnswers()
        {
            foreach (Card p in cards)
            {
                topics.Add(p.Answer);
            }
        }




    //    public void SelectCard(int id)
    //    {
    //        SQLiteConnection db = new SQLiteConnection(_pathToDatabase);

    //        //card.ID = ID;
    //        //card.Question = Question;
    //        //card.Answer = Answer;
    //        //card.Topic = Topic;
    //        lock (guard)
    //        {
    //            db.CreateTable<Card>();
    //        }


    //        //List<Card> cardList;

    //        lock (guard)
    //        {
    //            cards = db.Table<Card>().ToList();
    //        }

    //        if (cards.Count == 0)
    //        {
    //            var errorAlertController = UIAlertController.Create("Error", "there is no cards in library.", UIAlertControllerStyle.Alert);
    //            errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
    //            PresentViewController(errorAlertController, true, null);

    //        }
    //        else
    //        {
    //            foreach( Card p in cards)
    //            {
    //                if(p.ID == id)
    //                {
    //                    selectedCard = p;
    //                }
    //            }
    //        }

            

    //        db.Close();
    //    }



    }
}