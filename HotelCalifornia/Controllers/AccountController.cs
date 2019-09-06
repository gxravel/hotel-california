using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelCalifornia.Controllers
{
    /// <summary>
    /// Contains methods to create and use the account.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountStorage _storage;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="storage">An account storage</param>
        public AccountController(
            IAccountStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The register model</param>
        /// <returns>null if the operation was successfull</returns>
        /// <response code="204">The server successfully processed the register request, but is not returning any content</response>
        [HttpPost("register")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> Register(RegisterViewModel model)
        {
            return await _storage.Register(model);
        }

        /// <summary>
        /// Logs in to the system.
        /// </summary>
        /// <param name="model">The login model</param>
        /// <returns>null if the operation was successfull</returns>
        /// <response code="204">The server successfully processed the login request, but is not returning any content</response>
        [HttpPost("login")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> Login(LoginViewModel model)
        {
            return await _storage.Login(model);
        }

        /// <summary>
        /// Logs out of the system.
        /// </summary>
        /// <returns>null</returns>
        /// <response code="204">The server successfully processed the logout request, but is not returning any content</response>
        [HttpGet("logout")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> Logout()
        {
            return await _storage.Logout();
        }

    }
}
