using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.Auxiliary;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelCalifornia.Controllers
{
    /// <summary>
    /// Contains methods to operate with the hotel rooms.
    /// </summary>
    [Route("api/hotel/[controller]")]
    [ApiController]
    [Authorize(Roles = Constants.Roles.Admin)]
    public class RoomsController : Controller
    {
        private readonly IRoomsStorage _storage;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="storage">A rooms storage</param>
        public RoomsController(
            IRoomsStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Returns the list of the rooms.
        /// </summary>
        /// <param name="model">The get rooms model</param>
        /// <returns>The list of the rooms</returns>
        /// <response code="200">The request has succeeded with the list of the rooms.</response>
        [HttpGet("get")]
        [ProducesResponseType(200)]
        public async Task<ResponseModel> GetRooms([FromQuery]GetRoomsViewModel model)
        {
            return await _storage.GetRooms(model);
        }
    }
}
