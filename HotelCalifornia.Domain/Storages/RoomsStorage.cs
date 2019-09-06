using HotelCalifornia.Data.Repositories.Interfaces;
using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.Storages
{
    /// <summary>
    /// Contains methods: 
    /// <para><see cref="GetRooms(GetRoomsViewModel)"/></para>
    /// </summary>
    public class RoomsStorage : IRoomsStorage
    {
        private readonly IRoomsRepository _repository;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="repository">A rooms repository</param>
        public RoomsStorage(
            IRoomsRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns the list of the rooms.
        /// </summary>
        /// <param name="model">The get rooms model</param>
        /// <returns>The list of the rooms</returns>
        public async Task<ResponseModel> GetRooms(GetRoomsViewModel model)
        {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.RoomsOnPage = model.RoomsOnPage <= 0 ? 5 : model.RoomsOnPage;
            return await _repository.GetRooms(model);
        }
    }
}
