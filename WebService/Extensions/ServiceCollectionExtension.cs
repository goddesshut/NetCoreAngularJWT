using Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Security;
using WebService.Handler;

namespace WebService.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
        {
            DependencyInjector.RegisterServices(services);
            DependencyInjector.AddDbContext<AuthDbContext>(configuration.GetConnectionString("AuthContext"));

            //Seed
            DependencyInjector.GetService<AuthDbContext>().Seed();
        }

        public static void AddMvcCustom(this IServiceCollection service)
        {
            void Mvc(MvcOptions mvc)
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                mvc.Filters.Add(new AuthorizeFilter(policy));
            }

            void Json(MvcJsonOptions json)
            {
                json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }

            service.AddMvc(Mvc).AddJsonOptions(Json);
        }

        public static void AddAuthenticationCustom(this IServiceCollection services)
        {
            IJsonWebToken jsonWebToken = DependencyInjector.GetService<IJsonWebToken>();

            void JwtBearer(JwtBearerOptions jwtBearer)
            {
                jwtBearer.RequireHttpsMetadata = false;
                jwtBearer.SaveToken = true;
                jwtBearer.TokenValidationParameters = jsonWebToken.TokenValidationParameters;
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

    }
}
