using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
//this clase create map of objects to database
namespace StudyBugApp
{
    [Table("User")]
    class User66
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [MaxLength(20), Unique]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

    }
}