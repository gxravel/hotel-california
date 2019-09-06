using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages.Interfaces
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="CheckIntoRoom(CheckIntoRoomViewModel)"/></para>
    /// <para><see cref="CheckOutRoom(Guid)"/></para>
    /// </summary>
    public interface IGuestsStorage
    {
        /// <summary>
        /// Creates the guest entity.
        /// </summary>
        /// <param name="model">The check into the room model</param>
        /// <returns>The guest id</returns>
        public Task<ResponseModel> CheckIntoRoom(CheckIntoRoomViewModel model);

        /// <summary>
        /// Returns the guest corresponding to its id.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>The guest entity</returns>
        public Task<ResponseModel> CheckOutRoom(Guid guestId);

    }
}
