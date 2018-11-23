using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;

namespace StudyBugApp
{
    [Table ("Card")]
    class Card
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Question{ get; set; }

        public string Answer { get; set; }

        public string Topic { get; set; }


    }



}