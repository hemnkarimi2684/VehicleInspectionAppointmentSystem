namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.PasswordPolicy.PasswordExceptions;

public class PasswordSymbolException : Exception
{
    public PasswordSymbolException(string message) : base(message)
    {
        
    }
}
