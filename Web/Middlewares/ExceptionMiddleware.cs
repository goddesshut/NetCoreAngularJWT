using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Utils.Exceptions;
using Utils.Extensions;

namespace Web.Middlewares
{
    public class ExceptionMiddleware
    {
        readonly IHostingEnvironment _environment;
        readonly RequestDelegate _request;

        public ExceptionMiddleware(IHostingEnvironment environment, RequestDelegate request)
        {
            _environment = environment;
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context).ConfigureAwait(false);
            }
            catch (DomainException exception)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(exception.Message).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (_environment.IsDevelopment())
                {
                    throw;
                }

                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Text.Plain;
                await context.Response.WriteAsync(exception.GetDetail()).ConfigureAwait(false);
            }
        }
    }
}
