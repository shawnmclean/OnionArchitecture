// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseUserViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The base user view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OnionArchitecture.Web.Mvc.Models
{
    /// <summary>
    /// The base user view model.
    /// </summary>
    public abstract class BaseUserModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        #endregion
    }
}