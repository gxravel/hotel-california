using HotelCalifornia.Models.Auxiliary;
using System.ComponentModel.DataAnnotations;

namespace HotelCalifornia.Models.ViewModels
{
    /// <summary>
    /// Contains the properties expecting from the login request.
    /// <list type="bullet">
    /// <item>
    /// <term>Login</term>
    /// <description>Required string</description>
    /// </item>
    /// <item>
    /// <term>Password</term>
    /// <description>Required string</description>
    /// </item>
    /// </list>
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
