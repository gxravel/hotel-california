using HotelCalifornia.Data.Repositories.Interfaces;
using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.Data;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="CheckIntoRoom(CheckIntoRoomViewModel)"/></para>
    /// <para><see cref="CheckOutRoom(Guid)"/></para>
    /// </summary>
    public class GuestsStorage : IGuestsStorage
    {
        private readonly IGuestsRepository _repository;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="repository">The guests repository</param>
        public GuestsStorage(
            IGuestsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates the guest entity.
        /// </summary>
        /// <param name="model">The check into the room model</param>
        /// <returns>The guest id</returns>
        public async Task<ResponseModel> CheckIntoRoom(CheckIntoRoomViewModel model)
        {
            var guest = new Guest(model.RoomId, model.FullName);
            if (model.CheckIntoDate != null && model.CheckIntoDate > DateTime.Now)
            {
                guest.CheckIntoRoomDate = model.CheckIntoDate.GetValueOrDefault();
            }
            return await _repository.CheckIntoRoom(guest);
        }

        /// <summary>
        /// Returns the guest corresponding to its id.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>The guest entity</returns>
        public async Task<ResponseModel> CheckOutRoom(Guid guestId)
        {
            return await _repository.CheckOutRoom(guestId);
        }
    }
}
