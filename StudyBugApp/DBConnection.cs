using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using System.IO;

namespace StudyBugApp
{
    /// <summary>
    /// Used to connect to database.
    /// Author: Kendal Howse
    /// </summary>
    class DBConnection
    {
        public static string DBName = "StudyBugApp.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DBName);
        public static SQLiteConnection db;

        /// <summary>
        /// Creates the database file.
        /// </summary>
        public void CreateDB()
        {
            bool exists = File.Exists(DBPath);

            if (!exists)
            {
                try
                {
                    db = new SQLiteConnection(DBPath);
                    db.CreateTable<User>();
                    db.CreateTable<FacebookUser>();

                    Console.WriteLine(DBName);
                    Console.WriteLine(DBPath);
                }
                catch (Exception e)
                {

                }
            }
            
        }

        public SQLiteConnection GetDB()
        {
            return db;
        }

       
    }
}