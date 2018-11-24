using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// Data access object interface for Facebook users. 
    /// Author: Kendal Howse
    /// </summary>
    interface FacebookUserDAO
    {
        /// <summary>
        /// Gets a FacebookUser by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        FacebookUser GetFacebookUserByID(int ID);
        /// <summary>
        /// Used to insert a new FacebookUsers
        /// </summary>
        /// <param name="fbUser"></param>
        void InsertFacebookUser(FacebookUser fbUser);
        /// <summary>
        /// Returns a list of all the FacebookUsers in the Database.
        /// </summary>
        /// <returns></returns>
        List<FacebookUser> GetAllFacebookUsers();
        /// <summary>
        /// Update the users last login date
        /// </summary>
        /// <param name="login"></param>
        FacebookUser UpdateFacebookUserLoginTime(string login, int ID);
    }
}