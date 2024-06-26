using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shop.API.ActionFilters.Extensions
{
    public static class ExceptionContextExtensions
    {
        public static Task WriteErrorAsync(this ExceptionContext exceptionContext, int statusCode, params string[] errors)
        {
            var text = JsonSerializer.Serialize(new
            {
                Errors = errors
            });

            exceptionContext.HttpContext.Response.StatusCode = statusCode;
            exceptionContext.HttpContext.Response.ContentType = "application/json";
            return exceptionContext.HttpContext.Response.WriteAsync(text);
        }
    }
}
