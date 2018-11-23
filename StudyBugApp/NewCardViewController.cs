using System;
using System.IO;
using UIKit;
using SQLite;

namespace StudyBugApp
{
    public partial class NewCardViewController : UIViewController
    {



        object guard = new object();
        private string _pathToDatabase;

        public string Question { get; private set; }
        public string Answer { get; private set; }
        public string Topic { get; private set; }
        public int ID { get; private set; }



        public NewCardViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = false;
            NavigationItem.RightBarButtonItem = btnMenu;
            viewMenu.Hidden = true;
            
            _pathToDatabase = Path.Combine("..", "sqlite2.db");
        }

        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            viewMenu.Hidden = !viewMenu.Hidden;
        }

        public void TrimAllFields()
        {
            Topic = topic.Text.Trim();
            Question = question.Text.Trim();
            Answer = answer.Text.Trim();
        }


        partial void SaveBtn_TouchUpInside(UIButton sender)
        {
            if (Validate())
            {
                InsertCard();
                //var errorAlertController = UIAlertController.Create("Message", "Card Saved successfully.", UIAlertControllerStyle.Alert);
                //errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                //PresentViewController(errorAlertController, true, null);

            }
        }
        public Boolean Validate()
        {
            var valid = false;
            TrimAllFields();

            if (String.IsNullOrEmpty(Topic) || String.IsNullOrEmpty(Question) || String.IsNullOrEmpty(Answer))
            {
                var errorAlertController = UIAlertController.Create("Error", "Please fill out all required fields.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public void InsertCard()
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);
            Card card = new Card();
           
            card.Question = Question;
            card.Answer = Answer;
            card.Topic = Topic;
            lock (guard)
            {
                db.CreateTable<Card>();
            }
            lock (guard)
            {
                db.Insert(card);
            }
            db.Close();
        }


    }
}