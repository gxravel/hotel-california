using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.Data;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages
{
    /// <summary>
    /// Contains methods: 
    /// <para><see cref="Register(RegisterViewModel)"/></para>
    /// <para><seealso cref="Login(LoginViewModel)"/></para> 
    /// <para><seealso cref="Logout"/></para>
    /// Uses:
    /// <para><see cref="SignInManager{TUser}"/></para>
    /// <para><seealso cref="UserManager{TUser}"/></para>
    /// </summary>
    public class AccountStorage : IAccountStorage
    {
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="signManager">The sign in manager</param>
        /// <param name="userManager">The user manager</param>
        public AccountStorage(SignInManager<ApplicationUser> signManager,
                              UserManager<ApplicationUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The register model</param>
        /// <returns>null if success</returns>
        public async Task<ResponseModel> Register(RegisterViewModel model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                throw new ClientException("Password confirmation failed");
            }
            if (await _userManager.FindByNameAsync(model.Login) != null)
            {
                throw new ClientException($"The provided [Login = {model.Login}] already exists.");
            }
            var user = new ApplicationUser
            {
                UserName = model.Login
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create new user");
            }
            await _signManager.SignInAsync(user, false);
            return null;
        }

        /// <summary>
        /// Logs in to the system.
        /// </summary>
        /// <param name="model">The login model</param>
        /// <returns>null if success</returns>
        public async Task<ResponseModel> Login(LoginViewModel model)
        {
            var result = await _signManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (!result.Succeeded)
            {
                throw new ClientException("The provided login or password were incorrect");
            }
            return null;
        }

        /// <summary>
        /// Logs out of the system.
        /// </summary>
        /// <returns>null</returns>
        public async Task<ResponseModel> Logout()
        {
            await _signManager.SignOutAsync();
            return null;
        }
    }
}
