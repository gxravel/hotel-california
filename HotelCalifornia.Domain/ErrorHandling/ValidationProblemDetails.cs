using System;
using System.Collections.Generic;
using System.Text;

namespace HotelCalifornia.Domain.ErrorHandling
{
    /// <summary>
    /// Contains the model validation problem details.
    /// </summary>
    public class ValidationProblemDetails : ProblemDetails
    {
        /// <summary>
        /// Collection of the model validation errors.
        /// </summary>
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }
}
