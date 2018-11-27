using System;
using System.IO;
using UIKit;
using SQLite;

namespace StudyBugApp
{
    /// <summary>
    /// The new card page which allows the user to create a new card. 
    /// Page Design Author: Nisini Dias,
    /// Page Functionality and passing data to other pages (Pass new inserted card to next screen) Author: Ahmed Mohammed
    /// Page Navigation functionality with passing data between pages: Nandita Ghosh
    /// </summary>
    public partial class NewCardViewController : UIViewController
    {

        // Ahmed: guard ojbec to lock thread during database access
        object guard = new object();
        // Ahmed: database access path
        string _pathToDatabase = Path.Combine("..", "sqlite2.db");

        //Ahmed: property to store and retrieve questions, answers and topics
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public string Topic { get; private set; }
        public int ID { get; private set; }


        
        public NewCardViewController(IntPtr handle) : base(handle)
        {
        }


        /// <summary>
        /// Updates View after loading in order to add navigation panel.
        /// Author: Nandita Ghosh
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Ahmed: to enforce showing nav bar on screen
            NavigationController.NavigationBarHidden = false;

            NavigationItem.RightBarButtonItem = btnMenu;
           
            viewMenu.Hidden = true;
        }

        /// <summary>
        /// Toggle side menu panel.
        /// Author: Nandita Ghosh
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnMenu_Activated(UIBarButtonItem sender)
        {
            //toggle hide/show menu on click
            viewMenu.Hidden = !viewMenu.Hidden;
        }

       /// <summary>
       /// clean white spaces before and after strings inside fields
       /// Author: Ahmed Mohammed
       /// </summary>
        public void TrimAllFields()
        {
            //trim topic filed
            Topic = topic.Text.Trim();
            // tirm white spaces for Question field
            Question = question.Text.Trim();
            // tirm white spaces for Answer field
            Answer = answer.Text.Trim();
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// save button functionality to insert to database.. pass inserted card to screen and dismiss this screen
        /// </summary>
        /// <param name="sender"></param>
        partial void SaveBtn_TouchUpInside(UIButton sender)
        {
            //check if field is not empty to avoid inserting empty string
            if (Validate())
            {
                //insert to database
                InsertCard();
                //pass information to next screen after insertion
                this.DismissViewController(true, null);

            }
        }
        /// <summary>
        /// Author: Ahmed Mohammed
        /// check for vaild input (not empty)
        /// </summary>
        /// <returns>boolean</returns>
        public Boolean Validate()
        {
            // to check valid not empty input 
            var valid = false;
            //trim white spaces in all fields
            TrimAllFields();
            // check if all fields are not empty
            if (String.IsNullOrEmpty(Topic) || String.IsNullOrEmpty(Question) || String.IsNullOrEmpty(Answer))
            {
                // if one field is empty then error message should show up
                var errorAlertController = UIAlertController.Create("Error", "Please fill out all required fields.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);
            }
            else
            {
                //if all fields are not empty then valid is true
                valid = true;
            }

            //return valid
            return valid;
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// insert card details to database function
        /// </summary>
        public void InsertCard()
        {
            //start connection to database
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);
            Card card = new Card();
            //take information from fields
            card.Question = Question;
            card.Answer = Answer;
            card.Topic = Topic;
            // lock thread to start working on database
            lock (guard)
            {
                // create table if not exist
                db.CreateTable<Card>();
            }
            lock (guard)
            {
                // insert card to database
                db.Insert(card);
            }
            //close connection
            db.Close();
        }


        /// <summary>
        /// Author: Ahmed Mohammed
        /// cancel button functionality go back to previos screen
        /// </summary>
        /// <param name="sender"></param>
        partial void Canelbtn_TouchUpInside(UIButton sender)
        {
            //go back to previous screen and igonre insertion to database
            this.DismissViewController(true, null);
        }
    }
}