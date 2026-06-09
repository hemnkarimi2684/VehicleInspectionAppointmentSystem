namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.PasswordPolicy.PasswordExceptions;

public class PasswordTooShortExcption : Exception
{
    public PasswordTooShortExcption() : base("the lenght of password cannot be less than 8")
    {
        
    }
}
