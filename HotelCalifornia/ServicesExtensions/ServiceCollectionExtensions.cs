using HotelCalifornia.Config;
using HotelCalifornia.Data;
using HotelCalifornia.Data.Repositories;
using HotelCalifornia.Data.Repositories.Interfaces;
using HotelCalifornia.Domain.ErrorHandling;
using HotelCalifornia.Domain.Storages;
using HotelCalifornia.Domain.Storages.Interfaces;
using HotelCalifornia.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelCalifornia.ServicesExtensions
{
    /// <summary>
    /// The service collection extensions to hold the startup class clean and neat.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Services connected with the data.
        /// </summary>
        /// <param name="services">This service collection</param>
        /// <param name="connectionString">The credentials of the database</param>
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
        }

        /// <summary>
        /// Services connected with the Identity.
        /// </summary>
        /// <param name="services">This service collection</param>
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<DataContext>();

            services.Configure<IdentityOptions>(IdentityConfig.MainOptions);
            services.ConfigureApplicationCookie(IdentityConfig.ApplicationCookie);
            services.Configure<PasswordHasherOptions>(IdentityConfig.PasswordHasher);
        }

        /// <summary>
        /// The external services.
        /// </summary>
        /// <param name="services">This service collection</param>
        public static void AddExternalServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(SwaggerConfig.Gen);
        }

        /// <summary>
        /// My services: storages and repositories.
        /// </summary>
        /// <param name="services">This service collection</param>
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountStorage, AccountStorage>();
            services.AddScoped<IRoomsStorage, RoomsStorage>();
            services.AddScoped<IGuestsStorage, GuestsStorage>();

            services.AddScoped<IRoomsRepository, RoomsRepository>();
            services.AddScoped<IGuestsRepository, GuestsRepository>();
        }

        /// <summary>
        /// Configures the api behavior.
        /// </summary>
        /// <param name="services">This service collection</param>
        public static void ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx => new ValidationProblemDetailsResult();
            });
        }
    }
}
