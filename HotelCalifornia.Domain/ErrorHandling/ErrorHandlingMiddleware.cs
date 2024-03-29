﻿using HotelCalifornia.Models.ErrorHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.ErrorHandling
{
    /// <summary>
    /// The middlware for error handling.
    /// Logs and handles the global errors that were invoked.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        /// <summary>
        /// Provides dependency injection
        /// </summary>
        /// <param name="logger">A logger</param>
        /// <param name="next">The request delegate</param>
        public ErrorHandlingMiddleware(
            ILogger<ErrorHandlingMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// Performs the logging and executes the error handling actions if an error occured.
        /// </summary>
        /// <param name="context">An http context</param>
        /// <returns>Task when the middleware invoked</returns>
        public async Task Invoke(
            HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Defines the problem details according to <paramref name="ex"/> and writes the response.
        /// </summary>
        /// <param name="context">An http context</param>
        /// <param name="ex">The exception occured</param>
        /// <returns>Task when the response was written</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var problemDetails = new ProblemDetails();

            if (ex is BadHttpRequestException badHttpRequestException)
            {
                problemDetails.Title = "Invalid request";
                problemDetails.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
                    BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                problemDetails.Detail = badHttpRequestException.Message;
            }
            else if (ex is ClientException clientException)
            {
                problemDetails.Title = "Bad request";
                problemDetails.Status = clientException.StatusCode;
                problemDetails.Detail = clientException.Message;
            }
            else
            {
                problemDetails.Title = "An unexpected error occurred!";
                problemDetails.Status = 500;
                problemDetails.Detail = ex.Message;
            }

            // log the exception etc..

            context.Response.StatusCode = StatusCodes.Status200OK;
            return context.Response.WriteJson(problemDetails, "application/problem+json");
        }
    }
}
