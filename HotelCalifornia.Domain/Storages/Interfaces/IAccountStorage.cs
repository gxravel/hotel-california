using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
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
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The register model</param>
        /// <returns>null if success</returns>
        public Task<ResponseModel> Register(RegisterViewModel model);

        /// <summary>
        /// Logs in to the system.
        /// </summary>
        /// <param name="model">The login model</param>
        /// <returns>null if success</returns>
        public Task<ResponseModel> Login(LoginViewModel model);

        /// <summary>
        /// Logs out of the system.
        /// </summary>
        /// <returns>null</returns>
        public Task<ResponseModel> Logout();
    }
}
