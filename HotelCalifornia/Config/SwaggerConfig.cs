using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace HotelCalifornia.Config
{
    /// <summary>
    /// Contains configuration options for swagger.
    /// </summary>
    public class SwaggerConfig
    {
        private static string Name => "Hotel California";
        private static string Version => "v1";
        private static string Endpoint => $"/swagger/{Version}/swagger.json";
        private static string UIEndpoint => "";

        /// <summary>
        /// Defines the SwaggerUI options.
        /// </summary>
        /// <param name="config">The SwaggerUI optrions</param>
        public static void UI(SwaggerUIOptions config)
        {
            config.RoutePrefix = UIEndpoint;
            config.SwaggerEndpoint(Endpoint, Name);
        }

        /// <summary>
        /// Defines the SwaggerGen options.
        /// </summary>
        /// <param name="config">The SwaggerGen oprions</param>
        public static void Gen(SwaggerGenOptions config)
        {
            config.SwaggerDoc(
                Version,
                new OpenApiInfo { Version = Version, Title = Name });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        }
    }
}
