﻿using Foundation;
using System;
using UIKit;
using Xamarin.Auth;
using System.Json;
using System.IO;
using SQLite;
using SQLitePCL;
using System.Collections.Generic;
using System.Net.Mail;

namespace StudyBugApp
{
    /// <summary>
    /// The main screen of the application. Includes ability to sign in with email, and Facebook, or sign up for account.
    /// Author: Kendal Howse
    /// </summary>
    public partial class LoginScreen : UIViewController
    {
        object guard = new object();
        private string _pathToDatabase;
        /// <summary>
        /// ID retruned from Facebook Authentication
        /// </summary>
        public string fbID;
        /// <summary>
        /// First name retruned from Facebook Authentication
        /// </summary>
        public string fbFirstName;
        /// <summary>
        /// Last name retruned from Facebook Authentication
        /// </summary>
        public string fbLastName;
        /// <summary>
        /// Path to profile picture retruned from Facebook Authentication
        /// </summary>
        public string fbProfile;

        public string Name;
       
        protected LoginScreen(IntPtr handle) : base(handle)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //path to put database file in iPhone device
            var docmuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _pathToDatabase = Path.Combine("..", "sqlite2.db");

        }
        /// <summary>
        /// Event handler for Facebook login button. Establishes connection to Facebook's authentication, opens new UI for login.
        /// </summary>
        /// <param name="sender"></param>
        partial void FacebookLogin_TouchUpInside(UIButton sender)
        {
            var auth = new OAuth2Authenticator(clientId: "351547255592863", scope: "", authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"), redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
            auth.Completed += Auth_Completed;
            var ui = auth.GetUI();
            PresentViewController(ui, true, null);

        }
        /// <summary>
        /// Gets the authenticated user, and user information. This information will be used in database to store user data.
        /// Author: Kendal Howse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=id,first_name,last_name,picture"), null, e.Account);
                var response = await request.GetResponseAsync();
                //gets response from Facebook auth
                var user = JsonValue.Parse(response.GetResponseText());

                fbID = user["id"];
                fbFirstName = user["first_name"];
                fbLastName = user["last_name"];
                fbProfile = user["picture"]["data"]["url"];
                //logs user in to dashboard, passing name and profile picture
                PerformSegue("FacebookUser", this);
                
            }
            DismissViewController(true, null);
            
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            
        }
        /// <summary>
        /// Sets values for dashboard to receive
        /// Author: Kendal Howse, Nandita Ghosh
        /// </summary>
        /// <param name="segue"></param>
        /// <param name="sender"></param>
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "FacebookUser")
            { 
                var dashboard = segue.DestinationViewController as DashboardViewController;
                dashboard.Name = fbFirstName;
                dashboard.ProfilePicture = fbProfile;
            } else if (segue.Identifier == "Push")
            {
                var dashboard = segue.DestinationViewController as DashboardViewController;
                dashboard.Name = Name;
            }
        }
        /// <summary>
        /// Button event handler for log in. Checks if user exists, if not sign up.
        /// Author: Kendal Howse
        /// </summary>
        /// <param name="sender"></param>
        partial void BtnLogIn_TouchUpInside(UIButton sender)
        {
            if (!IsValidCredential())
            {
                var errorAlertController = UIAlertController.Create("Error", "Invalid Username/Password entered. Please try again.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);

            } else {
                
                this.PerformSegue("Push", this);
            }
        }
        
        /// <summary>
        /// Validates the data. Both fields must have data entry, and that data must exist in database.
        /// Author: Kendal Howse, Nandita Ghosh
        /// </summary>
        /// <returns></returns>
        private bool IsValidCredential()
        {
            var valid = false;

            if (String.IsNullOrEmpty(emailField.Text.Trim()) ||
                String.IsNullOrEmpty(passwordField.Text.Trim()))
            {
                valid = false;
            }
            
            else if (IsUserCredentialsExist())
            {
                valid = true;

            }


            return valid;
        }
        /// <summary>
        /// Checks if the user exists in the database
        /// Author: Ahmed Mohammed and Nandita Ghosh
        /// </summary>
        /// <returns></returns>
        public Boolean IsUserCredentialsExist()
        {
            Boolean isRight = false;

            SQLiteConnection conn = new SQLiteConnection(_pathToDatabase);
            conn.CreateTable<User>();
            User users = new User();
            List<User> userList;
            lock (guard)
            {
                userList = conn.Table<User>().ToList();
            }

            if (userList.Count != 0)
            {
                foreach (var p in userList)
                {
                    if (p.Email.Equals(emailField.Text.Trim()) && p.Password.Equals(passwordField.Text.Trim()))
                    {
                        Name = p.FirstName;
                        isRight = true;
                    }
                }

            }
            else
            {
                isRight = false;
                var errorAlertController = UIAlertController.Create("Error", "User does not exist. Please sign up.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);

            }

            conn.Close();

            return isRight;
        }

    }
}