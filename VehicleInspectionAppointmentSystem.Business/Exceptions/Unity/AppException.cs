using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.Unity;

namespace VehicleInspectionAppointmentSystem.Business.Exceptions.Unity;

public abstract class AppException : BaseException
{
    public AppException(string message, string statusCode, Exception innerException) : base(message, statusCode, innerException)
    {
    }

    public AppException(Error error, Exception? innerException = null) : base(error.Message, error.StatusCode, innerException)
    {
    }
}
