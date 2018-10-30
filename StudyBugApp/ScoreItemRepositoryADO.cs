using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StudyBugApp
{
    //repository design pattern implentation for database
    public class ScoreItemRepositoryADO
    {
        ScoreDatabase db = null;
        protected static string dbLocation;
        public static ScoreItemRepositoryADO me;

        static ScoreItemRepositoryADO()
        {
            me = new ScoreItemRepositoryADO();
        }

        public ScoreItemRepositoryADO()
        {
            // set file location and instatiate the database
            dbLocation = DatabaseFilePath;
            db = new ScoreDatabase(dbLocation);
        }

        public static string DatabaseFilePath
        {
            get
            {
                //Setting the location of the database
                var sqliteFilename = "ScoreDatabase1.db3";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                return path;
            }
        }

        public static ScoreItem GetItem(int id)
        {
            return me.db.GetItem(id);
        }

        public static IEnumerable<ScoreItem> GetTasks()
        {
            return me.db.GetItems();
        }

        public static int SaveItem(ScoreItem item)
        {
            return me.db.SaveItem(item);
        }

        public static int DeleteItem(int id)
        {
            return me.db.DeleteItem(id);
        }
    }
}