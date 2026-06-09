namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

public class InvalidPhoneNumberLengthException : Exception
{
    public InvalidPhoneNumberLengthException() : base("the phone number cannot be less or higher than 11 character")
    {

    }
}

