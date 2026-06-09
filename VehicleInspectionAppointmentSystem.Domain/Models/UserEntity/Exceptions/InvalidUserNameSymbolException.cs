namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

public class InvalidUserNameSymbolException : Exception
{
    public InvalidUserNameSymbolException() : base("the user name cannot have any symbol")
    {

    }
}

