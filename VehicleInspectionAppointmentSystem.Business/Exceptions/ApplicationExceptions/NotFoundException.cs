using VehicleInspectionAppointmentSystem.Business.Exceptions.Unity;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message, Exception? innerException = null) : base(message, "404", innerException)
    {
    }

    public NotFoundException(Error error, Exception? innerException = null) : base(error, innerException)
    {
    }
}
