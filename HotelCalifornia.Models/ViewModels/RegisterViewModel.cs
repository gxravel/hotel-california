using HotelCalifornia.Models.Auxiliary;
using System.ComponentModel.DataAnnotations;

namespace HotelCalifornia.Models.ViewModels
{
    /// <summary>
    /// Contains the properties expecting from the register request.
    /// <list type="bullet">
    /// <item>
    /// <term>Login</term>
    /// <description>Required string</description>
    /// </item>
    /// <item>
    /// <term>Password</term>
    /// <description>Required string</description>
    /// </item>
    /// <item>
    /// <term>PasswordConfirm</term>
    /// <description>Required string</description>
    /// </item>
    /// </list>
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
