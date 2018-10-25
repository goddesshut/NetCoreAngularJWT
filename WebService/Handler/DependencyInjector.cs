using BussinessLogic.Interfaces;
using BussinessLogic.Services;
using DataAccess.Interfaces;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security;
using System;

namespace WebService.Handler
{
    public static class DependencyInjector
    {
        static IServiceProvider ServiceProvider { get; set; }

        static IServiceCollection Services { get; set; }

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            Services.AddDbContext<T>(options => options.UseSqlServer(connectionString));
            var context = GetService<T>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }

        public static void AddDbContextInMemoryDatabase<T>() where T : DbContext
        {
            Services.AddDbContext<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            GetService<T>().Database.EnsureCreated();
        }

        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            Services = services;
            
            // Soulution Bussiness Logic
            Services.AddScoped<IAuthenticateServiceBLL, AuthenticateServiceBLL>();

            // Solution.CrossCutting
            Services.AddScoped<IJsonWebToken, JsonWebToken>();
            Services.AddScoped<IHash, Hash>();

            // Solution DataAccess
            Services.AddScoped<IProfileServiceDAL, ProfileServiceDAL>();
            Services.AddScoped<IRegistersServiceDAL, RegistersServiceDAL>();
            Services.AddScoped<IUserLogServiceDAL, UserLogServiceDAL>();

            return Services;
        }
    }
}
