using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace HotelCalifornia.Data.Repositories.Interfaces
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetRooms(GetRoomsViewModel)"/></para>
    /// <para><see cref="ChangeRoomStatus(Guid)"/></para>
    /// <para><see cref="GetRoom(Guid)"/></para>
    /// <para><see cref="GetState(Guid)"/></para>
    /// </summary>
    public interface IRoomsRepository
    {
        /// <summary>
        /// Returns the list of the rooms.
        /// </summary>
        /// <param name="model">The get rooms model</param>
        /// <returns>The list of the rooms</returns>
        public Task<ResponseModel> GetRooms(GetRoomsViewModel model);

        /// <summary>
        /// Changes the room status to occupied / not occupied.
        /// </summary>
        /// <param name="roomId">The room Id</param>
        /// <returns>null if success</returns>
        public Task<ResponseModel> ChangeRoomStatus(Guid roomId);

        /// <summary>
        /// Returns the room corresponding to its id.
        /// </summary>
        /// <param name="roomId">The room id</param>
        /// <returns>The room enitity</returns>
        public Task<ResponseModel> GetRoom(Guid roomId);

        /// <summary>
        /// Returns the room state (occupied / not occupied).
        /// </summary>
        /// <param name="roomId">The room id</param>
        /// <returns>true/false</returns>
        public Task<ResponseModel> GetState(Guid roomId);
    }
}
