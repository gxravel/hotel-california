using HotelCalifornia.Data.Repositories.Interfaces;
using HotelCalifornia.Models.Auxiliary;
using HotelCalifornia.Models.Data;
using HotelCalifornia.Models.ErrorHandling;
using HotelCalifornia.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCalifornia.Data.Repositories
{
    /// <summary>
    /// Contains methods:
    /// <para><see cref="GetRooms(GetRoomsViewModel)"/></para>
    /// <para><see cref="ChangeRoomStatus(Guid)"/></para>
    /// <para><see cref="GetRoom(Guid)"/></para>
    /// <para><see cref="GetState(Guid)"/></para>
    /// </summary>
    public class RoomsRepository : IRoomsRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Provides dependency injection
        /// </summary>
        /// <param name="context">The database context</param>
        public RoomsRepository(
            DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns the list of the rooms.
        /// </summary>
        /// <param name="model">The get rooms model</param>
        /// <returns>The list of the rooms</returns>
        public async Task<ResponseModel> GetRooms(GetRoomsViewModel model)
        {
            var query = _context.HotelRooms
                                .AsNoTracking();

            query = model.FindColumn switch
            {
                Enums.HotelRoomColumns.Id => query.Where(x => x.Id.ToString().Contains(model.FindValue)),
                Enums.HotelRoomColumns.Capacity => query.Where(x => x.Capacity.ToString().Contains(model.FindValue)),
                Enums.HotelRoomColumns.Type => query.Where(x => ((int)x.Type).ToString().Contains(model.FindValue)),
                Enums.HotelRoomColumns.IsOccupied => query.Where(x => x.IsOccupied.ToString().Contains(model.FindValue)),
                Enums.HotelRoomColumns.Cost => query.Where(x => x.Cost.ToString().Contains(model.FindValue)),
                _ => query
            };
            if (model.IsAscending)
            {
                query = model.SortColumn switch
                {
                    Enums.HotelRoomColumns.Capacity => query.OrderBy(x => x.Capacity),
                    Enums.HotelRoomColumns.Type => query.OrderBy(x => x.Type),
                    Enums.HotelRoomColumns.IsOccupied => query.OrderBy(x => x.IsOccupied),
                    Enums.HotelRoomColumns.Cost => query.OrderBy(x => x.Cost),
                    _ => query.OrderBy(x => x.Id)
                };
            }
            else
            {
                query = model.SortColumn switch
                {
                    Enums.HotelRoomColumns.Capacity => query.OrderByDescending(x => x.Capacity),
                    Enums.HotelRoomColumns.Type => query.OrderByDescending(x => x.Type),
                    Enums.HotelRoomColumns.IsOccupied => query.OrderByDescending(x => x.IsOccupied),
                    Enums.HotelRoomColumns.Cost => query.OrderByDescending(x => x.Cost),
                    _ => query.OrderByDescending(x => x.Id)
                };
            }
            var rooms = await query.Skip((model.Page - 1) * model.RoomsOnPage)
                                   .Take(model.RoomsOnPage)
                                   .ToListAsync();
            return new ResponseModel(rooms);
        }

        /// <summary>
        /// Changes the room status to occupied / not occupied.
        /// </summary>
        /// <param name="roomId">The room Id</param>
        /// <returns>null if success</returns>
        public async Task<ResponseModel> ChangeRoomStatus(Guid roomId)
        {
            var room = (await GetRoom(roomId)).Response as HotelRoom;

            room.IsOccupied = !room.IsOccupied;

            _context.HotelRooms
                .Update(room);

            await _context.SaveChangesAsync();
            return null;
        }

        /// <summary>
        /// Returns the room corresponding to its id.
        /// </summary>
        /// <param name="roomId">The room id</param>
        /// <returns>The room enitity</returns>
        public async Task<ResponseModel> GetRoom(Guid roomId)
        {
            var room = await _context.HotelRooms
                .Where(x => x.Id == roomId)
                .FirstOrDefaultAsync();

            if (room == null)
            {
                throw new ClientException($"The provided [RoomId = {roomId}] was incorrect");
            }

            return new ResponseModel(room);
        }

        /// <summary>
        /// Returns the room state (occupied / not occupied).
        /// </summary>
        /// <param name="roomId">The room id</param>
        /// <returns>true/false</returns>
        public async Task<ResponseModel> GetState(Guid roomId)
        {
            var roomState = await _context.HotelRooms
                .Where(x => x.Id == roomId)
                .Select(x => x.IsOccupied)
                .FirstOrDefaultAsync();

            return new ResponseModel(roomState);
        }
    }
}
