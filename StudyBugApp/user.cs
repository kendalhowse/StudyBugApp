using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
//this class create map of objects to database
namespace StudyBugApp
{
    /// <summary>
    /// Author: Ahmed Mohammed
    /// create user table
    /// </summary>
    /// 
    //annotation to create table User in database
    [Table("User")]
    class User
    {
        //set primary key and autoincrement in table in database
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //create Auto-setter getter properties And Column name
        public string FirstName { get; set; }
        //create Auto-setter getter properties And Column name
        public string LastName { get; set; }
        //create Auto-setter getter properties And Column name set unique value constraints and max is 20 char
        [MaxLength(20), Unique]
        public string Email { get; set; }
        //create Auto-setter getter properties And Column name set column max to 20 char for passowrd
        [MaxLength(20)]
        public string Password { get; set; }
        

    }
}