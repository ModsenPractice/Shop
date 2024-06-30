using FluentValidation;
using Shop.API.ActionFilters.Extensions;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Shop.BLL.Exceptions;

namespace Shop.API.ActionFilters;

public class HttpGlobalExceptionHandler(IHostEnvironment environment) : IExceptionHandler
{
    private readonly IHostEnvironment _environment = environment ?? throw new ArgumentNullException(nameof(environment));

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var task = exception switch
        {
            ValidationException validationException => HandleValidationException(httpContext, validationException),
            BadRequestException badRequestException => HandleBadRequestException(httpContext, badRequestException),
            NotFoundException notFoundException => HandleNotFoundException(httpContext, notFoundException),
            _ => HandleError(httpContext, exception),
        };

        await task;

        return true;
    }

    private Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            validationException.Errors.Select(x => x.ErrorMessage).ToArray());
    }

    private Task HandleNotFoundException(HttpContext context, NotFoundException notFoundException)
    {
        return context.WriteErrorAsync(HttpStatusCode.NotFound,
            _environment.IsDevelopment() ? notFoundException.Message : "Resource not found");
    }

    private Task HandleBadRequestException(HttpContext context, BadRequestException badHttpRequestException)
    {
        return context.WriteErrorAsync(HttpStatusCode.BadRequest,
            _environment.IsDevelopment() ? badHttpRequestException.Message : "Bad request");
    }

    private Task HandleError(HttpContext context, Exception exception)
    {
        return context.WriteErrorAsync(HttpStatusCode.InternalServerError,
            _environment.IsDevelopment() ? exception.Message : "An unexpected error occured");
    }
}