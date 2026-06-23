using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.Unity;

namespace VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;

public class DomainException : BaseException
{
    public DomainException(string message, string statusCode, Exception? innerException = null) : base(message, statusCode, innerException)
    {
    }

    public DomainException(Error error, Exception? innerException = null) : base(error.Message, error.StatusCode, innerException)
    {

    }
}
