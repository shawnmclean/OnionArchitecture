// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserCreateViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The user create view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OnionArchitecture.Web.Mvc.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The user create view model.
    /// </summary>
    public class UserCreateModel : BaseUserModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        #endregion
    }
}