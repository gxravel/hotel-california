using HotelCalifornia.Models.Data;
using HotelCalifornia.Models.ErrorHandling;
using System;
using System.Threading.Tasks;

namespace HotelCalifornia.Data.Repositories.Interfaces
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="CheckIntoRoom(Guest)"/></para>
    /// <para><see cref="CheckOutRoom(Guid)"/></para>
    /// <para><see cref="GetGuest(Guid)"/></para>
    /// </summary>
    public interface IGuestsRepository
    {
        /// <summary>
        /// Records that a guest is checked into the room.
        /// </summary>
        /// <param name="guest">The guest to check into the room</param>
        /// <returns>The guest id</returns>
        public Task<ResponseModel> CheckIntoRoom(Guest guest);

        /// <summary>
        /// Clears the room and calculates the cost.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>The total accomodation cost</returns>
        public Task<ResponseModel> CheckOutRoom(Guid guestId);

        /// <summary>
        /// Returns the guest corresponding to its id.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>The guest entity</returns>
        public Task<ResponseModel> GetGuest(Guid guestId);
    }
}
