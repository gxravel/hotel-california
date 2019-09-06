using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages.Interfaces
{
    /// <summary>
    /// Contains methods: 
    /// <para><see cref="GetRooms(GetRoomsViewModel)"/></para>
    /// </summary>
    public interface IRoomsStorage
    {
        /// <summary>
        /// Returns the list of the rooms.
        /// </summary>
        /// <param name="model">The get rooms model</param>
        /// <returns>The list of the rooms</returns>
        public Task<ResponseModel> GetRooms(GetRoomsViewModel model);
    }
}
