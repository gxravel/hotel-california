using HotelCalifornia.Models.Auxiliary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;

namespace HotelCalifornia.Config
{
    /// <summary>
    /// Contains configuration options for identity.
    /// </summary>
    public class IdentityConfig
    {
        /// <summary>
        /// Defines the main options connected with lockout, signin and user settings.
        /// </summary>
        /// <param name="options">The identity options</param>
        public static void MainOptions(IdentityOptions options)
        {
            // Default Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = Constants.MinPasswordLength;
            options.Password.RequiredUniqueChars = 0;
            // Default SignIn settings.
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // Default User settings.
            options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        }

        /// <summary>
        /// Defines the application cookie optrions.
        /// </summary>
        /// <param name="options">The cookie authentication options</param>
        public static void ApplicationCookie(CookieAuthenticationOptions options)
        {
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.Cookie.Name = "HotelCaliforniaCookie";
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.LoginPath = "/account/login";
            options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            options.SlidingExpiration = true;
        }

        /// <summary>
        /// Defines the password hasher options.
        /// </summary>
        /// <param name="options">The password hasher options</param>
        public static void PasswordHasher(PasswordHasherOptions options)
        {
            options.IterationCount = 12000;
        }
    }
}
