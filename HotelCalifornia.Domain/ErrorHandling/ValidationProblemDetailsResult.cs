using HotelCalifornia.Models.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationProblemDetails = HotelCalifornia.Models.ErrorHandling.ValidationProblemDetails;

namespace HotelCalifornia.Domain.ErrorHandling
{
    /// <summary>
    /// Services to redefine the default behavior of validation the model state.
    /// </summary>
    public class ValidationProblemDetailsResult : IActionResult
    {
        /// <summary>
        /// Writes the validation errors in http response.
        /// </summary>
        /// <param name="context">ActionContext parameter</param>
        /// <returns>Task when the response was written</returns>
        public Task ExecuteResultAsync(ActionContext context)
        {
            var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();
            var errors = new List<ValidationError>();

            var details = "See ValidationErrors for details";

            if (modelStateEntries.Any())
            {
                if (modelStateEntries.Length == 1 && modelStateEntries[0].Value.Errors.Count == 1 && modelStateEntries[0].Key == string.Empty)
                {
                    details = modelStateEntries[0].Value.Errors[0].ErrorMessage;
                }
                else
                {
                    foreach (var modelStateEntry in modelStateEntries)
                    {
                        foreach (var modelStateError in modelStateEntry.Value.Errors)
                        {
                            var error = new ValidationError
                            {
                                Name = modelStateEntry.Key,
                                Description = modelStateError.ErrorMessage
                            };

                            errors.Add(error);
                        }
                    }
                }
            }

            var problemDetails = new ValidationProblemDetails
            {
                Status = 400,
                Title = "Request Validation Error",
                Detail = details,
                ValidationErrors = errors
            };

            return context.HttpContext.Response.WriteJson(problemDetails);
        }
    }
}
