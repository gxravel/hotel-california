using HotelCalifornia.Models.Auxiliary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCalifornia.Config
{
    public class IdentityConfig
    {
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

        public static void PasswordHasher(PasswordHasherOptions options)
        {
            options.IterationCount = 12000;
        }
    }
}
