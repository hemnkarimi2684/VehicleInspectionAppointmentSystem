using VehicleInspectionAppointmentSystem.Business.Common.Exceptions.Unity;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Business.Common.Exceptions.ApplicationExceptions;

public class ConflictException : AppException
{
    public ConflictException(string message, Exception? innerException = null) : base(message, "CONFLICT", innerException)
    {
    }

    public ConflictException(Error error, Exception? innerException = null) : base(error, innerException)
    {
    }
}
