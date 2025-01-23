
using Newtonsoft.Json;
using Npgsql;
using System.Net;
using System.Security.Claims;
using test.Helpers;

namespace test.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //var result = "An error occurred while processing your request.";

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new BaseResponse
            {
                Success = false,
                Message = ex.Message,
                Code = context.Response.StatusCode
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }

}
