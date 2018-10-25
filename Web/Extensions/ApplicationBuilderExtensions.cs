using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Middlewares;

namespace Web.Extensions
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

        public static void UseSpaCustom(this IApplicationBuilder application, IHostingEnvironment environment)
        {
            application.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (environment.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "development");
                }
            });
        }

    }
}
