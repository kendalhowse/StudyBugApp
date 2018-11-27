
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;
using SQLite;
using System.Linq;

namespace StudyBugApp
{   /// <summary>
/// 
/// Autohr: Ahmed Mohammed
/// show card list of all cards from database
/// </summary>

    public partial class ShowCardListUITableViewController : UITableViewController

    {
        /// <summary>
        /// author: Ahmed MOhammed
        /// table view Source object
        /// </summary>
        CardListTableViewSource tableSource;
        //card list
        List<Card> cards;
        //topic list to be shown
        private List<string> topics;
        private List<string> distTopics;
        List<string> Questions;
        List<string> Answers;
        Card selectedCard;

        //guard ojbec to lock thread during database access
        object guard = new object();
        //path to database
        private string _pathToDatabase;

        
        
        public ShowCardListUITableViewController (IntPtr handle) : base (handle)
        {
        }
        /// <summary>
        /// Author: ahmed mohammed
        /// on page load perform actions
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
          
            _pathToDatabase = Path.Combine("..", "sqlite2.db");
            //load list of all items from table
            GetAllCard();
            //get all topics to be shown as titles for the cards in the list
            GetAllTopics();
            //pass topics list to table source for THIS controller
            tableSource = new CardListTableViewSource(topics, this);
            //set teh source of our current list to the table source
            ShowListTableView.Source = tableSource;
            //to pass information to card details page from the cell tapped 
            tableSource.NewPageEvent += HandleNewPage;
        }



    
        /// <summary>
        /// Author: Ahmed Mohammed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleNewPage(object sender, EventArgs e)
        {
            // pass this controller data to Card details veiw controller
            this.NavigationController.PushViewController(new CardDetailsViewController(), true);
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// GetAll cards form database used to get titles to shown in list here
        /// </summary>
        public void GetAllCard()
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);

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

        /// <summary>
        /// Author: Ahmed Mohammed
        /// from cards get the topics to be shown in the list
        /// </summary>
        public void GetAllTopics()
        {
           //topics list
            topics = new List<string>();
            //set list of topics 
            foreach (var p in cards)
            {
                string str = p.Topic;
                topics.Add(str);
            }
            // get unique list of topics (not used now.. to be used if we want to categorize by topic)
            distTopics = cards.Select(x => x.Topic).Distinct().ToList();
        }
        /// <summary>
        /// Author: Ahmed Mohammed
        /// to get all questions to be used to search by question (Not used Now)
        /// </summary>
        public void GetAllQuestions()
        {
            foreach (Card p in cards)
            {
                topics.Add(p.Question);
            }
        }


        /// <summary>
        /// Author: Ahmed Mohammed
        /// to get all answer to be used to search by answer (Not used Now)
        /// </summary>
        public void GetAllAnswers()
        {
            foreach (Card p in cards)
            {
                topics.Add(p.Answer);
            }
        }






    }
}