namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

public class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
        
    }
}
