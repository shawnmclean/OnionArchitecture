using System;

namespace OnionArchitecture.Core.Domain
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
