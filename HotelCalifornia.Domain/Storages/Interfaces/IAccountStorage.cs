using HotelCalifornia.Domain.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages.Interfaces
{
    /// <summary>
    /// Contains methods: 
    /// <para><see cref="Register(RegisterViewModel)"/></para>
    /// <para><seealso cref="Login(LoginViewModel)"/></para> 
    /// <para><seealso cref="Logout"/></para>
    /// </summary>
    public interface IAccountStorage
    {
        public Task<ResponseModel> Register(RegisterViewModel model);
        public Task<ResponseModel> Login(LoginViewModel model);
        public Task<ResponseModel> Logout();
    }
}
