using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// Data acces object for Facebook Users. 
    /// Author: Kendal Howse
    /// </summary>
    class FacebookUserDAOImpl : FacebookUserDAO
    {
        DBConnection DB = new DBConnection();
        object guard = new object();
        /// <summary>
        /// Returns all FacebookUsers in teh database.
        /// Author: Kendal Howse
        /// </summary>
        /// <returns></returns>
        public List<FacebookUser> GetAllFacebookUsers()
        {
            List<FacebookUser> userList;

            lock (guard)
            {
                userList = DB.GetDB().Table<FacebookUser>().ToList();
            }

            return userList;
        }
        /// <summary>
        /// Gets a Facebook user by ID.
        /// Author: Kendal Howse
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public FacebookUser GetFacebookUserByID(int ID)
        {
            FacebookUser user = new FacebookUser();
            var query = DB.GetDB().Query<FacebookUser>("select * from FacebookUser where id = ?", ID);
            
            foreach(FacebookUser f in query)
            {
                user = f;
            }

            return user;
        }

        /// <summary>
        /// Inserts a Facebook User in the database.
        /// Author: Kendal Howse
        /// </summary>
        /// <param name="fbUser"></param>
        public void InsertFacebookUser(FacebookUser fbUser)
        {
            lock (guard)
            {
                DB.GetDB().Insert(fbUser);
            }
        }
        /// <summary>
        /// Updates a Facebook Users last login date.
        /// Author: Kendal Howse
        /// </summary>
        /// <param name="login"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public FacebookUser UpdateFacebookUserLoginTime(string login, int ID)
        {
            FacebookUser user = new FacebookUser();
            var query = DB.GetDB().Query<FacebookUser>("update FacebookUser set LastLogin = ? where ID = ?", login, ID);
            
            foreach (FacebookUser f in query)
            {
                user = f;
            }

            return user;
        }

    }
}