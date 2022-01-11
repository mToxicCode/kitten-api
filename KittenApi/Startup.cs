using KittenApi.BusinessLayer.Abstractions;
using KittenApi.BusinessLayer.Users;
using KittenApi.BusinessLayer.Users.Handlers;
using KittenApi.BusinessLayer.Users.Handlers.Create;
using KittenApi.BusinessLayer.Users.Handlers.Delete;
using KittenApi.BusinessLayer.Users.Handlers.Get;
using KittenApi.DataLayer.Extensions;
using KittenApi.Dtos;
using KittenApi.Dtos.CreateUser;
using KittenApi.Dtos.GetUser;
using KittenApi.Dtos.GetUsers;
using KittenApi.Infrastructure.Extensions;
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
            => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            services.AddDatabaseInfrastructure(_configuration);
            services.AddControllers();
            services.AddSwagger();
            services
                .AddHttpContextAccessor()
                .AddSingleton<HttpCancellationTokenAccessor>()
                .AddSingleton<IUsersService, UsersServiceResolver>()
                .AddSingleton<UsersHandlersProvider>()
                .AddSingleton<IHandler<CreateUserRequest, CreateUserResponse>, CreateUserHandler>()
                .AddSingleton<IHandler<long, GetUserResponse>, GetUserHandler>()
                .AddSingleton<IHandler<GetUsersResponse>, GetUsersHandler>()
                .AddSingleton<IHandler<long, Empty>, DeleteUserHandler>();
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
            app.Migrate();
        }
    }
}