using HotelCalifornia.Data.Repositories.Interfaces;
using HotelCalifornia.Models.Data;
using HotelCalifornia.Models.ErrorHandling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCalifornia.Data.Repositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="CheckIntoRoom(Guest)"/></para>
    /// <para><see cref="CheckOutRoom(Guid)"/></para>
    /// <para><see cref="GetGuest(Guid)"/></para>
    /// </summary>
    public class GuestsRepository : IGuestsRepository
    {
        private readonly DataContext _context;
        private readonly IRoomsRepository _roomsRepository;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="context">The database context</param>
        public GuestsRepository(
            IRoomsRepository roomsRepository,
            DataContext context)
        {
            _roomsRepository = roomsRepository;
            _context = context;
        }

        /// <summary>
        /// Records that a guest is checked into the room.
        /// </summary>
        /// <param name="guest">The guest to check into the room</param>
        /// <returns>The guest id</returns>
        public async Task<ResponseModel> CheckIntoRoom(Guest guest)
        {
            bool isOccupied = (bool)(await _roomsRepository.GetState(guest.RoomId)).Response;
            if (isOccupied)
            {
                throw new ClientException($"The room [RoomId = {guest.RoomId}] is occupied");
            }
            await _roomsRepository.ChangeRoomStatus(guest.RoomId);
            await _context.Guests.AddAsync(guest);

            await _context.SaveChangesAsync();
            return new ResponseModel(guest.Id);
        }

        /// <summary>
        /// Clears the room and calculates the cost.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>The total accomodation cost</returns>
        public async Task<ResponseModel> CheckOutRoom(Guid guestId)
        {
            var guest = (await GetGuest(guestId)).Response as Guest;
            await _roomsRepository.ChangeRoomStatus(guest.RoomId);

            guest.CheckOutRoomDate = DateTime.Now;
            var cost = HotelRoom.CalculateCostForEntirePeriod(guest.CheckIntoRoomDate, guest.CheckOutRoomDate, guest.Room.Cost);
            _context.Guests
                .Remove(guest);

            await _context.SaveChangesAsync();
            if (cost == 0f)
            {
                cost = guest.Room.Cost;
            }
            return new ResponseModel(cost);
        }

        /// <summary>
        /// Returns the guest corresponding to its id.
        /// </summary>
        /// <param name="guestId">The guest id</param>
        /// <returns>The guest entity</returns>
        public async Task<ResponseModel> GetGuest(Guid guestId)
        {
            var guest = await _context.Guests
                .Where(x => x.Id == guestId)
                .FirstOrDefaultAsync();

            if (guest == null)
            {
                throw new ClientException($"There is no such a guest with [Id = {guestId}");
            }
            return new ResponseModel(guest);
        }
    }
}
