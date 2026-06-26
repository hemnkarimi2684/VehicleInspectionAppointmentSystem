using VehicleInspectionAppointmentSystem.Business.Exceptions.Unity;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;

public class ValidationException : AppException
{
    public ValidationException(string message, Exception? innerException = null) : base(message, "BADREQUEST", innerException)
    {
    }

    public ValidationException(Error error, Exception? innerException = null) : base(error, innerException)
    {
    }
}
