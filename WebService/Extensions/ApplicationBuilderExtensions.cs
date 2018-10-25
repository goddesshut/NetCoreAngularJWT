using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebService.Middlewares;

namespace WebService.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCorsCustom(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
        }

        public static void UseExceptionCustom(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseExceptionMiddleware();
        }

        public static void UseExceptionMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHstsCustom(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                return;
            }

            application.UseHsts();
        }

    }
}
