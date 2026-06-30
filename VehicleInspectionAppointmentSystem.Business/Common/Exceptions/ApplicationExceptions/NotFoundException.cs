using VehicleInspectionAppointmentSystem.Business.Common.Exceptions.Unity;
using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Business.Common.Exceptions.ApplicationExceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message, Exception? innerException = null) : base(message, "NOTFOUND", innerException)
    {
    }

    public NotFoundException(Error error, Exception? innerException = null) : base(error, innerException)
    {
    }
}
