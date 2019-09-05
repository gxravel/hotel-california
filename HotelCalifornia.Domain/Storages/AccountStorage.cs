using HotelCalifornia.Domain.ErrorHandling;
using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.Data;
using HotelCalifornia.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages
{
    public class AccountStorage : IAccountStorage
    {
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountStorage(SignInManager<ApplicationUser> signManager,
                              UserManager<ApplicationUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

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

        public async Task<ResponseModel> Login(LoginViewModel model)
        {
            var result = await _signManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (!result.Succeeded)
            {
                throw new ClientException("The provided login or password were incorrect");
            }
            return null;
        }

        public async Task<ResponseModel> Logout()
        {
            await _signManager.SignOutAsync();
            return null;
        }
    }
}
