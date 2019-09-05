using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelCalifornia.Models.Data
{
    /// <summary>
    /// The <c>ApplicationUser</c> class for authorization system.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
