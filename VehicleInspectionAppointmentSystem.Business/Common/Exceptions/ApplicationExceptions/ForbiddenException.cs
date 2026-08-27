using VehicleInspectionAppointmentSystem.Business.Common.Exceptions.Unity;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Business.Common.Exceptions.ApplicationExceptions;

public class ForbiddenException : AppException
{
    public ForbiddenException(string message, Exception? innerException = null) : base(message, "FORIBIDDEN", innerException)
    {
    }

    public ForbiddenException(Error error, Exception? innerException = null) : base(error, innerException)
    {
    }
}
