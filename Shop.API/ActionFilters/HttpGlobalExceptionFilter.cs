using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.API.ActionFilters.Extensions;
using Shop.BLL.Common.Exceptions.BadRequestExceptions;
using Shop.BLL.Common.Exceptions.NotFoundExceptions;

namespace Shop.API.ActionFilters;

public class HttpGlobalExceptionFilter(IHostEnvironment environment) : IAsyncExceptionFilter
{
    private readonly IHostEnvironment _environment = environment ?? throw new ArgumentNullException(nameof(environment));

    public Task OnExceptionAsync(ExceptionContext context)
    {
        context.ExceptionHandled = true;
        var exception = context.Exception;

        var task = exception switch
        {
            ValidationException validationException => HandleValidationException(context, validationException),
            BadRequestException badRequestException => HandleBadRequestException(context, badRequestException),
            NotFoundException notFoundException => HandleNotFoundException(context, notFoundException),
            _ => HandleError(context),
        };

        return task;
    }

    private Task HandleValidationException(ExceptionContext context, ValidationException validationException)
    {
        return context.WriteErrorAsync(400,
            _environment.IsDevelopment()
                ? validationException.Errors.Select(x => x.ErrorMessage).ToArray()
                : ["Bad request"]);
    }

    private Task HandleNotFoundException(ExceptionContext context, NotFoundException notFoundException)
    {
        return context.WriteErrorAsync(404,
            _environment.IsDevelopment() ? notFoundException.Message : "Resource not found");
    }

    private Task HandleBadRequestException(ExceptionContext context, BadRequestException badHttpRequestException)
    {
        return context.WriteErrorAsync(400,
            _environment.IsDevelopment() ? badHttpRequestException.Message : "Bad request");
    }

    private Task HandleError(ExceptionContext context)
    {
        return context.WriteErrorAsync(500,
            _environment.IsDevelopment() ? context.Exception.Message : "An unexpected error occured");
    }
}