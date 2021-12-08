using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace DesafioAtos.Application.Core.Middlewares.Exceptions
{
    public class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(WebApplication app)
        {
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "text/html";
                        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();

                        if (null != exceptionObject)
                        {
                            var errorMessage = $"{exceptionObject.Error.Message}";
                            await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                        }
                    });
                }
            );
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}