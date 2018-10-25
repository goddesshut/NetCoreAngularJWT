using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMvcCustom(this IServiceCollection services)
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

            services.AddMvc(Mvc).AddJsonOptions(Json);
        }

        public static void AddSpaStaticFilesCustom(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(spa => spa.RootPath = "ClientApp/dist");
        }

    }
}
