using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Middlewares
{
	public static class ExceptionHandle
	{
        public static void UseMyExceptionHandle(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
					context.Response.ContentType = "text/plain";
					var exception =
                        context.Features.Get<IExceptionHandlerFeature>();
                    await context.Response.WriteAsync(exception.Error.Message);
                });
            });
        }
    }
}
