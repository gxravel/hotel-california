using HotelCalifornia.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelCalifornia.Data
{
    /// <summary>
    /// The Identity database context class.
    /// </summary>
    public class DataContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        /// <summary>
        /// The default <c>IdentityDbContext</c> constructor
        /// </summary>
        /// <param name="options">The database context options</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// The database table for hotel rooms.
        /// </summary>
        public DbSet<HotelRoom> HotelRooms { get; set; }

        /// <summary>
        /// The database table for guests.
        /// </summary>
        public DbSet<Guest> Guests { get; set; }
    }
}
