namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

public class TooShortLengthException : Exception
{
    public TooShortLengthException(string message) : base(message)
    {

    }
}

