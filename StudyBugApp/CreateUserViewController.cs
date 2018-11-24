using Foundation;
using System;
using UIKit;

using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;

namespace StudyBugApp
{
    /// <summary>
    /// This screen appears when the user hits the SignUp button. All fields will be entered, and inserted into database.
    /// Author: Kendal Howse
    /// </summary>
    public partial class CreateUserViewController : UIViewController
    {
        object guard = new object();
        /// <summary>
        /// First name of new user
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of new user
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Password for new user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Confirm password value for new user
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Email value for new user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Relative path to database
        /// </summary>
        private string _pathToDatabase;

        public CreateUserViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _pathToDatabase = Path.Combine("..", "sqlite2.db");
        }
        /// <summary>
        /// This method validates that the data entry is suitable. No fields can be null or empty, and password and confirm password must be the same.
        /// </summary>
        /// Author: Kendal Howse
        /// <returns>Boolean value "valid". Returns false if data is wrong, true is data is valid.</returns>
        public Boolean Validate()
        {
            var valid = false;
            TrimAllFields();
            
            
            if (!String.IsNullOrEmpty(Email))
            {
                try
                {
                    //ensures that email is proper format
                    MailAddress m = new MailAddress(Email);

                }
                catch (FormatException)
                {
                    //shows error message if not proper format
                    var errorAlertController = UIAlertController.Create("Error", "Email address is not in valid format. Please try again.", UIAlertControllerStyle.Alert);
                    errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(errorAlertController, true, null);

                    return false;
                }
            }
            //checks if any fields are blank
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(ConfirmPassword) || String.IsNullOrEmpty(Email))
            {
                var errorAlertController = UIAlertController.Create("Error", "Please fill out all required fields.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);
            } 
            //ensures password and confirm password fields match - if not shows error message
            else if (!String.Equals(Password, ConfirmPassword))
            {
                var errorAlertController = UIAlertController.Create("Error", "Passwords do not match, please try again.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);
            } else
            {
                valid = true;
            }

            return valid;
        }

        /// <summary>
        /// Trims all the field data to avoid issues with trailing blank spaces.
        /// Author: Kendal Howse
        /// </summary>
        public void TrimAllFields()
        {
            Email = email.Text.Trim();
            Password = password.Text.Trim();
            ConfirmPassword = confirmPassword.Text.Trim();
            FirstName= firstName.Text.Trim();
            LastName = lastName.Text.Trim();
        }

        /// <summary>
        /// Event handler for SignUp button. First validates data, then will insert into database if valid.
        /// </summary>
        /// <param name="sender"></param>
        partial void SignUp_TouchUpInside(UIKit.UIButton sender)
        {
            if (Validate())
            {
                InsertNewUser();
               
            }
        }
        /// <summary>
        /// Inserts user into the database.
        /// Author: Ahmed Mohammed
        /// </summary>
        public void InsertNewUser()
        {
            SQLiteConnection db = new SQLiteConnection(_pathToDatabase);
            User users = new User();
            users.FirstName = FirstName;
            users.LastName = LastName;
            users.Password = Password;
            users.Email = Email;

            //creates table users
            lock (guard)
            {
                db.CreateTable<User>();
            }


            List<User> userList;
            //retreives all values in database
            lock (guard)
            {
                userList = db.Table<User>().ToList();
            }

            if (userList.Count != 0)
            {

                foreach (var p in userList)
                {
                    if (!p.Email.Equals(email.Text.Trim()))
                    {
                        lock (guard)
                        {
                            db.Insert(users);
                        }
                    }
                    else
                    {
                        //if exists already, error message
                        var errorAlertController = UIAlertController.Create("Error", "Email already exist please login.", UIAlertControllerStyle.Alert);
                        errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        PresentViewController(errorAlertController, true, null);
                    }
                }
            }
            else
            {
                lock (guard)
                {
                    db.Insert(users);
                }
            }



            db.Close();
        }


    }
}