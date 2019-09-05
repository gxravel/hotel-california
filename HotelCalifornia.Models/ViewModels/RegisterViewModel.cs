using HotelCalifornia.Models.Auxiliary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelCalifornia.Models.ViewModels
{
    /// <summary>
    /// Contains the properties expecting from the register request.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Login of a new user.
        /// </summary>
        [Required]
        [MinLength(Constants.MinLoginLength)]
        public string Login { get; set; }

        /// <summary>
        /// Password of a new user.
        /// </summary>
        [Required]
        [MinLength(Constants.MinPasswordLength)]
        public string Password { get; set; }

        /// <summary>
        /// Password confirmation of a new user.
        /// </summary>
        [Required]
        public string PasswordConfirm { get; set; }
    }
}
