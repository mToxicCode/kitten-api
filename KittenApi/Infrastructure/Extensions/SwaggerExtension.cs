using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace KittenApi.Infrastructure.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "KittenApi",
                    Description = "A simple API for service to work with .csv files",
                    TermsOfService = new Uri("https://github.com/daniilda/top-course-work/blob/master/README.md"),
                    Contact = new OpenApiContact
                    {
                        Name = "Daniil Kuznetsov",
                        Email = "daniilda@hotmail.com",
                        Url = new Uri("https://github.com/daniilda")
                    }
                });
            });
        }
    }
}