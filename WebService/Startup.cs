using BussinessLogic.Interfaces;
using BussinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security;
using WebService.Extensions;

namespace WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjectionCustom(Configuration);
            services.AddAuthenticationCustom();
            services.AddCors();
            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddMvcCustom();
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
        {
            application.UseExceptionCustom(environment);
            application.UseAuthentication();
            application.UseCorsCustom();
            application.UseHstsCustom(environment);
            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseResponseCaching();
            application.UseMvcWithDefaultRoute();
        }
    }
}
