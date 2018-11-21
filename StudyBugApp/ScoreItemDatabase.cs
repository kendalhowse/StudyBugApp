using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


using Mono.Data.Sqlite;
using System.Data;
using Foundation;
using SQLite;
using UIKit;

namespace StudyBugApp
{
    //Database for score items and possibly other parts of the application
    public class ScoreDatabase
    {
        static object locker = new object();

        public SqliteConnection connection;

        public string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>

        public ScoreDatabase(string dbPath)
        {

            path = dbPath;
            // create the tables
            bool exists = File.Exists(dbPath);
            //if it doesn't already exist, creates connection
            if (!exists)
            {
                connection = new SqliteConnection("Data Source=" + dbPath);

                connection.Open();
                var commands = new[] {
                    //add tables here
                    //"DROP TABLE [Items];"
                    "CREATE TABLE [Items] (_id INTEGER PRIMARY KEY ASC, Name NTEXT, Score NTEXT);",
                    "CREATE TABLE [Users] (_id INTEGER PRIMARY KEY ASC, First NTEXT, Last NTEXT, Email NTEXT, Password NTEXT);"//, Done INTEGER
				};
                foreach (var command in commands)
                {
                    //runs the array of commands passed into array
                    using (var c = connection.CreateCommand())
                    {
                        c.CommandText = command;
                        c.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                // if the connection alredy exists, do nothing
            }
        }

        //This converts SQL info to DataTransfer object
        ScoreItem FromReader(SqliteDataReader r)
        {
            var t = new ScoreItem();
            t.ID = Convert.ToInt32(r["_id"]);
            t.Name = r["First"].ToString();
            t.Lastn = r["Last"].ToString();
            t.Email = r["Email"].ToString();
            t.Password = r["Password"].ToString();
            return t;
        }
        //this is supposed to return multiple rows of SQL query... work in progress
        public IEnumerable<ScoreItem> GetItems()
        {
            var ItemList = new List<ScoreItem>();

            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var contents = connection.CreateCommand())
                {
                    contents.CommandText = "SELECT [_id], [Name], [Last], [Email], [Password] from [Users]";
                    var r = contents.ExecuteReader();
                    while (r.Read())
                    {
                        //adds reader items to array
                        ItemList.Add(FromReader(r));
                    }
                }
                connection.Close();
            }
            return ItemList;
        }
        //this returns an item from the database based on item ID
        public ScoreItem GetItem(int id)
        {
            var t = new ScoreItem();
            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //command.CommandText = "SELECT [_id], [First], [Last],[Email],[Password] from [Users] WHERE [_id] = ?";
                    command.CommandText = "SELECT [_id], [First], [Last], [Email], [Password] from [Users] WHERE [_id] = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        t = FromReader(r);
                        break;
                    }
                }
                connection.Close();
            }
            return t;
        }
        //this returns a user with a given email
        public ScoreItem GetUser(String email)
        {
            var t = new ScoreItem();
            lock (locker)
            {
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Name] from [Users] WHERE [Email] = ?";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = email });
                    var r = command.ExecuteReader();
                    while (r.Read())
                    {
                        t = FromReader(r);
                        break;
                    }
                }
                connection.Close();
            }
            return t;
        }

        public int SaveItem(ScoreItem item)
        {
            int r;
            lock (locker)
            {
                if (item.ID != 0)
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE [Items] SET [First] = ?, [Last] = ? WHERE [_id] = ?;";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Name });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Lastn });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Password });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Email });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.ID });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }
                else
                {
                    connection = new SqliteConnection("Data Source=" + path);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [Users] ([First], [Last],[Email],[Password]) VALUES (?,?,?,?)";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Name });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Lastn });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Password });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Email });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }

            }
        }
        //deletes items - not currently working because I switched the tables around
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                int r;
                connection = new SqliteConnection("Data Source=" + path);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Items] WHERE [_id] = ?;";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    r = command.ExecuteNonQuery();
                }
                connection.Close();
                return r;
            }
        }
    }
}
