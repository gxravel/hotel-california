using HotelCalifornia.Models.Auxiliary;
using HotelCalifornia.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HotelCalifornia.Data
{
    /// <summary>
    /// Contains the method that initializes the database.
    /// </summary>
    public class DataSeeder
    {
        private readonly DataContext _context;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Provides dependency injection.
        /// </summary>
        /// <param name="context">A database context</param>
        /// <param name="roleManager">The role manager</param>
        /// <param name="userManager">The user manager</param>
        public DataSeeder(
            DataContext context,
            RoleManager<Role> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Initializes the database.
        /// </summary>
        /// <returns>Task when completed</returns>
        public async Task Initialize()
        {
            Guid roomId = Guid.NewGuid();
            if (!await _context.HotelRooms.AnyAsync())
            {
                #region initRooms
                var room = new HotelRoom();
                await _context.AddAsync(room);
                room = new HotelRoom(2, Enums.HotelRoomTypes.Suite);
                await _context.AddAsync(room);
                room = new HotelRoom(1, Enums.HotelRoomTypes.JuniorSuite);
                await _context.AddAsync(room);
                room = new HotelRoom(3, Enums.HotelRoomTypes.Standard, true);
                roomId = room.Id;
                await _context.AddAsync(room);
                await _context.SaveChangesAsync();
                #endregion
            }
            if (!await _context.Guests.AnyAsync())
            {
                #region initGuests
                var guest = new Guest(roomId, "Mustafa");
                await _context.AddAsync(guest);
                await _context.SaveChangesAsync();
                #endregion
            }
            foreach (var roleName in Constants.Roles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new Role(roleName));
                }
            }
            if (!await _userManager.Users.AnyAsync())
            {
                var admin = new ApplicationUser
                {
                    UserName = "rav3L"
                };
                string adminPassword = "1Ravil*";
                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRolesAsync(admin, Constants.Roles.All);
            }
        }
    }
}
