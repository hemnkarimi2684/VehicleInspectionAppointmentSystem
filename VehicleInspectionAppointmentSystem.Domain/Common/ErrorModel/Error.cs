namespace VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

public class Error
{
    public Error(string message, string statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public string Message { get; private set; }

    public string StatusCode { get; private set; }
}
