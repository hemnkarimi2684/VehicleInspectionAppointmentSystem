namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException() : base("invalid phone number! the phone number must be number")
    {
        
    }
}
