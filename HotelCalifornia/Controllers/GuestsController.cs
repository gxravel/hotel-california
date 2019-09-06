using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace HotelCalifornia.Controllers
{
    /// <summary>
    /// Contains methods to manage checking into/out of a room.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GuestsController : Controller
    {
        private readonly IGuestsStorage _storage;

        /// <summary>
        /// Provides dependency injection
        /// </summary>
        /// <param name="storage">The guests storage</param>
        public GuestsController(
            IGuestsStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Checks the guest into the room.
        /// </summary>
        /// <param name="model">The chec into the room model</param>
        /// <returns>The guest id</returns>
        /// <response code="201">The server successfully created new record of the guest.</response>
        [HttpPost("check-into-room")]
        [ProducesResponseType(201)]
        public async Task<ResponseModel> CheckIntoRoom(CheckIntoRoomViewModel model)
        {
            return await _storage.CheckIntoRoom(model);
        }

        /// <summary>
        /// Checks the guest out of the room and calculates the cost.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>null if the operation was successfull</returns>
        /// <response code="204">The server successfully processed the checking out request, but is not returning any content</response>
        [HttpDelete("check-out-room")]
        [ProducesResponseType(204)]
        public async Task<ResponseModel> CheckOutRoom(Guid guestId)
        {
            return await _storage.CheckOutRoom(guestId);
        }
    }
}
