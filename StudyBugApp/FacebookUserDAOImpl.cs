using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StudyBugApp
{
    class FacebookUserDAOImpl : FacebookUserDAO
    {
        DBConnection DB = new DBConnection();
        object guard = new object();
        public List<FacebookUser> GetAllFacebookUsers()
        {
            List<FacebookUser> userList;

            lock (guard)
            {
                userList = DB.GetDB().Table<FacebookUser>().ToList();
            }

            return userList;
        }

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

        public void InsertFacebookUser(FacebookUser fbUser)
        {
            lock (guard)
            {
                DB.GetDB().Insert(fbUser);
            }
        }

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