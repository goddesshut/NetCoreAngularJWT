using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Extensions;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment)
        {
            //Custom Configure
            application.UseExceptionCustom(environment);
            //application.UseAuthentication();
            application.UseCorsCustom();
            application.UseHstsCustom(environment);
            //application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseSpaStaticFiles();
            //application.UseMvcWithDefaultRoute();
            application.UseSpaCustom(environment);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddResponseCaching();
            services.AddMemoryCache();
            //services.AddMvcCustom();
            services.AddSpaStaticFilesCustom();
        }

    }
}
