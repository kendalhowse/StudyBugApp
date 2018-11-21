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
    /// Data access object to represent a Facebook User.
    /// </summary>
    [Table("FacebookUser")]
    class FacebookUser
    {
        /// <summary>
        /// This int property is the value returned as the ID from Facebook Validation
        /// </summary>
        [Unique]
        public int ID { get; set; }
        /// <summary>
        /// First name retreived from Facebook authentication.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name retreived from Facebook authentication.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// URL to the users profile picture from Facebook authentication.
        /// </summary>
        public string ProfilePicture { get; set; }
        /// <summary>
        /// Users last login date.
        /// </summary>
        public string LastLogin { get; set; }
    }
}