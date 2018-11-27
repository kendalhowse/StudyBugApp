using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;

namespace StudyBugApp
{
    /// <summary>
    /// Author: Ahmed Mohammed
    /// create card table in database that holds
    /// topic , question , Answer, ID
    /// </summary>
    //Annotation to name the table
    [Table ("Card")]
    class Card
    {
        //set primary key and autoincrement in table in database
        [PrimaryKey, AutoIncrement]
        //create Auto-setter getter properties And Column name
        public int ID { get; set; }
        //create Auto-setter getter properties And Column name
        public string Question{ get; set; }
        //create Auto-setter getter properties And Column name
        public string Answer { get; set; }
        //create Auto-setter getter properties And Column name
        public string Topic { get; set; }


    }



}