using System.Net;
using System.Text.Json;
using FluentValidation;
using TodoList.Core.Exceptions;

namespace TodoList.Api.Middlewares;

public class ExceptionsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionsMiddleware> _logger;

    public ExceptionsMiddleware(
        RequestDelegate next,
        ILogger<ExceptionsMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = MapExceptionTypeToHttpCode(e);

        var response = new
        {
            error = e.Message,
            type = e.GetType().Name,
            status = context.Response.StatusCode
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private int MapExceptionTypeToHttpCode(Exception e)
    {
        _logger.LogError(e, "Exception occured:");

        switch (e)
        {
            case UnauthorizedAccessException:
                return (int)HttpStatusCode.Unauthorized;

            case ValidationException:
            case DataNotFoundException:
                return (int)HttpStatusCode.BadRequest;

            default:
                return (int)HttpStatusCode.InternalServerError;
        }

    }
}