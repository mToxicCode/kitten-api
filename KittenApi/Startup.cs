﻿using KittenApi.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KittenApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var type = typeof(Startup);
            services.AddControllers();
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints
                => endpoints.MapControllers());
            
            app
                .UseSwagger()
                .UseSwaggerUI(opt
                    =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TOPCourseworkBL");
                    opt.RoutePrefix = string.Empty;
                });

        }
    }
}