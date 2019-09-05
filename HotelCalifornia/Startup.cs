using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotelCalifornia.Config;
using HotelCalifornia.Data;
using HotelCalifornia.Domain.ErrorHandling;
using HotelCalifornia.Domain.Storages;
using HotelCalifornia.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProblemDetails = HotelCalifornia.Domain.ErrorHandling.ProblemDetails;

namespace HotelCalifornia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx => new ValidationProblemDetailsResult();
            });

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<DataContext>();

            services.Configure<IdentityOptions>(IdentityConfig.MainOptions);
            services.ConfigureApplicationCookie(IdentityConfig.ApplicationCookie);
            services.Configure<PasswordHasherOptions>(IdentityConfig.PasswordHasher);
            
            services.AddSwaggerGen(SwaggerConfig.Gen);

            services.AddScoped<AccountStorage>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(SwaggerConfig.UI);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
