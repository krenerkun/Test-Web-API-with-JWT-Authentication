using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Context;
using WebAPI.Managers;
using WebAPI.Managers.Interfaces;
using WebAPI.Model;
using WebAPI.Repositories;
using WebAPI.Repositories.Common;
using WebAPI.Repositories.Interfaces;

namespace WebAPI
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();


            services.AddDbContext<RefreshTokenContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("MainDbConnectionString"));
            });


            services.AddControllers();


            //Dependency Injections
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IRefreshTokensRepository, RefreshTokenRepository>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IRefreshTokensManager, RefreshTokenManager>();
            services.Configure<AppSettings>(appSettingsSection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
