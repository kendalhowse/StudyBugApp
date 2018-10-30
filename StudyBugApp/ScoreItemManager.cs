using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StudyBugApp
{
    //accessoble methods to call throughout the app to modify the database- every method that needs to be accessible in database
    //should be referenced here
    public static class ScoreItemManager
    {
        static ScoreItemManager()
        {
        }
        //returns the full item at an id value
        public static ScoreItem GetItem(int id)
        {
            return ScoreItemRepositoryADO.GetItem(id);
        }
        //supposed to return all score items with intention of sticking them in some kind of list view
        public static IList<ScoreItem> GetItems()
        {
            return new List<ScoreItem>(ScoreItemRepositoryADO.GetTasks());
        }
        //saves a score item (autoincrements primary key)
        public static int SaveItem(ScoreItem item)
        {
            return ScoreItemRepositoryADO.SaveItem(item);
        }
        //deletes score item in the database at given ID
        public static int DeleteItem(int id)
        {
            return ScoreItemRepositoryADO.DeleteItem(id);
        }
    }
}