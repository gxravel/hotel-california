using Microsoft.AspNetCore.Identity;
using System;

namespace HotelCalifornia.Models.Data
{
    /// <summary>
    /// The <c>IdentityRole</c> class for enabling roles in authorization system.
    /// </summary>
    public class Role : IdentityRole<Guid>
    {
        /// <summary>
        /// Initializes the Name of the role with <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the role</param>
        public Role(string name)
        {
            this.Name = name;
        }
    }
}
