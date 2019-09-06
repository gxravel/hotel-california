using System.Collections.Generic;

namespace HotelCalifornia.Models.ErrorHandling
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
