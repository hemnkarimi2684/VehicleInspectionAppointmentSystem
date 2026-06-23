using VehicleInspectionAppointmentSystem.Business.Exceptions.Unity;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;

public class ForbiddenException : AppException
{
    public ForbiddenException(string message, Exception? innerException = null) : base(message, "403", innerException)
    {
    }

    public ForbiddenException(Error error, Exception? innerException = null) : base(error, innerException)
    {
    }
}
