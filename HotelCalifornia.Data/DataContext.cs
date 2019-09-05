using HotelCalifornia.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelCalifornia.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<ApplicationUser>()
        //        .HasIndex(u => u.NormalizedUserName)
        //        .IsUnique();
        //    base.OnModelCreating(builder);
        //}
    }
}
