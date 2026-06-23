namespace VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.Unity;

public class BaseException : Exception
{
    public BaseException(string message, string statusCode, Exception innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
    }

    public string StatusCode { get; }
}
