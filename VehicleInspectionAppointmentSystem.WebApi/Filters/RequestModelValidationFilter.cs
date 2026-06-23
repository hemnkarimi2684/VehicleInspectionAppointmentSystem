using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace VehicleInspectionAppointmentSystem.WebApi.Filters;

public class RequestModelValidationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                                      .SelectMany(v => v.Errors)
                                      .Select(e => e.ErrorMessage);

            throw new VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions.ValidationException(string.Join(", ", errors));
        }
    }
}
