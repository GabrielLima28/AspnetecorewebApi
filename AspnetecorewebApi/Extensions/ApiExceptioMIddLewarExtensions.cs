using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using AspnetecorewebApi.Model;
using Microsoft.AspNetCore.Diagnostics;

namespace AspnetecorewebApi.Extensions
{
    public static class  ApiExceptioMIddLewarExtensions
   {
        /// <summary>
        /// Tratamento de exeção global 
        /// </summary>
        /// <param name="app"
        /// >
        /// Extensão do aplicativo 
        /// Essa classe será resposnavel por tratar as exceções globais da aplicação 
        /// 
        /// </param>
        /// <returns></returns>

        public static async Task ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {

                appError.Run(async
                  
                
                context =>
                {


                    ///<summary>
                    ///
                    /// error 500 
                    /// Serivodr interno 
                    /// 
                    /// </summary>


                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature is not null)
                        {
                            var errorDetails = new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server Error.",
                                Trace = contextFeature.Error.StackTrace
                            };
                            await context.Response.WriteAsync(errorDetails.ToString());
                        }
                    }

                    ///<summary>
                    ///tratando exceções que não foram encontradas 
                    ///error 400 notfound 
                    /// 
                    /// </summary>


                    else if (!context.Request.RouteValues.All(x => x.Value != null))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest; 
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature is not null)
                        {
                            var errorDetails = new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server Error.",
                                Trace = contextFeature.Error.StackTrace
                            };
                            await context.Response.WriteAsync(errorDetails.ToString());
                        }
                    }
                    
                  

                });


            });



        }
    }
}
