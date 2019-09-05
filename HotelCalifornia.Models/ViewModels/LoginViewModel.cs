using HotelCalifornia.Models.Auxiliary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelCalifornia.Models.ViewModels
{
    /// <summary>
    /// Contains the properties expecting from the login request.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Login of the user.
        /// </summary>
        [Required]
        [MinLength(Constants.MinLoginLength)]
        public string Login { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        [Required]
        [MinLength(Constants.MinPasswordLength)]
        public string Password { get; set; }
    }
}
