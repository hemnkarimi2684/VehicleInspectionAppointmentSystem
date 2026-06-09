namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

public class InvalidUserNameLengthException : Exception
{
    public InvalidUserNameLengthException() : base("Your user name must be at least 3 characters long or Shorter than 20 characters.")
    {

    }
}

