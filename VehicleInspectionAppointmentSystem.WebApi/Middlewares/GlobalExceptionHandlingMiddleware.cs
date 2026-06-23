using System.Text.Json;
using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;
using VehicleInspectionAppointmentSystem.WebApi.ResultPattern;

namespace VehicleInspectionAppointmentSystem.WebApi.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);

        }
        catch (Exception exception)
        {
            await ExceptionHandlerAsync(context, exception);
        }
    }

    private async Task ExceptionHandlerAsync(HttpContext context, Exception exception)
    {
        switch (exception)
        {
            case NotFoundException notFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(GenerateResponseBody(notFoundException.Message, notFoundException.StatusCode));
                break;
            case ConflictException conflictException:
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(GenerateResponseBody(conflictException.Message, conflictException.StatusCode));
                break;
            case ValidationException validationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(GenerateResponseBody(validationException.Message, validationException.StatusCode));
                break;
            case ForbiddenException forbiddenException:
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(GenerateResponseBody(forbiddenException.Message, forbiddenException.StatusCode));
                break;
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(GenerateResponseBody
                    ("InternalServerError_500", "Something went wrong. Please contact your administrator."));
                break;
        }
    }

    private string GenerateResponseBody(string message, string code)
    {
        var error = new Error(message, code);

        var result = Result.Failure(error);

        return JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}
