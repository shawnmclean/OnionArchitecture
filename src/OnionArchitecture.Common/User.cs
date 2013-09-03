using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Common
{
    /// <summary>
    /// Entity representing a user
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// The Date when the user was added to the system.
        /// </summary>
        public DateTime DateCreated { get; set; }

    }
}
