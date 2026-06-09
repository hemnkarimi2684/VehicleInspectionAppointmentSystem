namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.PasswordPolicy.PasswordExceptions;

public class PasswordMissingDigitException : Exception
{
    public PasswordMissingDigitException(string message) : base(message)
    {
        
    }
}
