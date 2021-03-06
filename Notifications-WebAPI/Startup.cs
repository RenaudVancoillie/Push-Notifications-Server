using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Notifications_DAL.Database;
using Notifications_DAL.Repositories.Subscriptions;
using Notifications_DAL.Services.Subscriptions;
using Notifications_WebAPI.Helpers;
using Notifications_WebAPI.Helpers.Managers.Notifications;

namespace Notifications_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISubscriptionsRepository, SubscriptionsRepository>();
            services.AddScoped<ISubscriptionsService, SubscriptionsService>();
            services.AddScoped<INotificationsManager, NotificationsManager>();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<NotificationsContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Local"));
                });
            }
            if (_env.IsProduction())
            {
                services.AddDbContext<NotificationsContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("Heroku"));
                });
            }

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowAnyOrigin();
            }));

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Notifications_WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notifications WebAPI v1"));

            app.UseCors("CorsPolicy");

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
