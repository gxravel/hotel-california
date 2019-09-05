using System;
using System.Collections.Generic;
using System.Text;

namespace HotelCalifornia.Domain.ErrorHandling
{
    /// <summary>
    /// Describes the model validation error.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Name of the field the error occured with.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the error.
        /// </summary>
        public string Description { get; set; }
    }
}
