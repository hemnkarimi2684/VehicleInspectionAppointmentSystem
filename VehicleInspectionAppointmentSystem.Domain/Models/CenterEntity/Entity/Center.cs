using System.ComponentModel.DataAnnotations;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;

namespace VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;

// مرکز معاینه فنی
public class Center : BaseEntity
{
    private Center() { }

    public Center(int centerCode, string name, string address, int dailyMaxCapacity, string? managerName, string phoneNumber, int cityId)
    {
        CenterCode = centerCode;
        Name = name;
        Address = address;
        DailyMaxCapacity = dailyMaxCapacity;
        ManagerName = managerName;
        PhoneNumber = phoneNumber;
        CityId = cityId;

        FixPhoneNumberFormat();
        Validate();
    }

    public int CenterCode { get; private set; }

    public string Name { get; private set; }

    public string Address { get; private set; }

    [Range(0, 20)]
    public int DailyMaxCapacity { get; private set; }

    public string? ManagerName { get; private set; }

    public string PhoneNumber { get; private set; }

    //Foreign Key
    public int CityId { get; private set; }

    //Navigation Property
    public virtual City City { get; private set; }

    public virtual ICollection<TimeSlot> TimeSlots { get; private set; } = new List<TimeSlot>();

    protected override void Validate()
    {
        if (CenterCode < 1)
            throw new InvalidOperationException("invalid CenterCode!");

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentNullException("the center name cannot be null");

        if (Name.Length < 2 || Name.Length > 150)
            throw new InvalidOperationException("the center name length cannot be less than 2 or higher than 150");

        if (string.IsNullOrWhiteSpace(Address))
            throw new ArgumentNullException("the Address cannot be null");

        if (Address.Length < 2 || Address.Length > 200)
            throw new InvalidOperationException("the Address length cannot be less than 2 or higher than 200");

        if (DailyMaxCapacity < 0 || DailyMaxCapacity > 20)
            throw new InvalidOperationException("invalid DailyMaxCapacity! the DailyMaxCapacity cannot be less than 0 and higher than 20");

        if (!string.IsNullOrWhiteSpace(ManagerName) && ManagerName.Length < 2 || ManagerName.Length > 120)
            throw new InvalidOperationException("the center name length cannot be less than 2 or higher than 120");

        ValidatePhoneNumber();

        if (CityId < 1)
            throw new InvalidOperationException("invalid CityId!");
    }

    private void ValidatePhoneNumber()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
            throw new ArgumentNullException("your phone number cannot be null or empty");

        if (PhoneNumber.Length != 11)
            throw new InvalidPhoneNumberLengthException();

        if (!PhoneNumber.All(char.IsDigit))
            throw new InvalidPhoneNumberException();
    }

    private void FixPhoneNumberFormat()
    {
        if (PhoneNumber.StartsWith("+98"))
            PhoneNumber = $"09{PhoneNumber.Substring(3)}";
    }

}
