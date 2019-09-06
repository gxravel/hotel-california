using Microsoft.AspNetCore.Identity;
using System;

namespace HotelCalifornia.Models.Data
{
    /// <summary>
    /// The <c>IdentityUser</c> class for authorization system.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}