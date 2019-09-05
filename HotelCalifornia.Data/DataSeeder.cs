using HotelCalifornia.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelCalifornia.Data
{
    public class DataSeeder
    {
        private readonly DbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(
            DbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task Initialize()
        {
            if (!await _userManager.Users.AnyAsync())
            {
                var admin = new ApplicationUser
                {
                    UserName = "rav3L"
                };
                string adminPassword = "1Ravil*";
                await _userManager.CreateAsync(admin, adminPassword);
            }
        }
    }
}
