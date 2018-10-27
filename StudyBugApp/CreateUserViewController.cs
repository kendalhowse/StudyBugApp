using Foundation;
using System;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// This screen appears when the user hits the SignUp button. All fields will be entered, and inserted into database.
    /// Kendal Howse
    /// </summary>
    public partial class CreateUserViewController : UIViewController
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }


        public CreateUserViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
        /// <summary>
        /// This method validates that the data entry is suitable. No fields can be null or empty, and password and confirm password must be the same.
        /// </summary>
        /// <returns>Boolean value "valid". Returns false if data is wrong, true is data is valid.</returns>
        public Boolean Validate()
        {
            var valid = false;
            TrimAllFields();
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(ConfirmPassword) || String.IsNullOrEmpty(Email))
            {
                var errorAlertController = UIAlertController.Create("Error", "Please fill out all required fields.", UIAlertControllerStyle.Alert);
                errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(errorAlertController, true, null);
            } 
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

        public void InsertNewUser()
        {
            // This method needs connection to database
            // will be called once data has been validated
            // Insert all attributes: FirstName, LastName, Email and Password
        }


    }
}