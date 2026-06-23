using System.ComponentModel.DataAnnotations;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;

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
            throw new DomainException(DomainErrors.InvalidCenterCodeRange);

        if (string.IsNullOrWhiteSpace(Name))
            throw new DomainException(DomainErrors.CenterNameIsRequired);

        if (Name.Length < 2 || Name.Length > 150)
            throw new DomainException(DomainErrors.InvalidCenterNameLength);

        if (string.IsNullOrWhiteSpace(Address))
            throw new DomainException(DomainErrors.CenterAddressIsRequired);

        if (Address.Length < 2 || Address.Length > 200)
            throw new DomainException(DomainErrors.InvalidCenterAddressLength);

        if (DailyMaxCapacity < 0 || DailyMaxCapacity > 20)
            throw new DomainException(DomainErrors.InvalidDailyMaxCapacityRange);

        if (!string.IsNullOrWhiteSpace(ManagerName) && ManagerName.Length < 2 || ManagerName.Length > 120)
            throw new DomainException(DomainErrors.InvalidCenterManagerNameLength);

        ValidatePhoneNumber();

        if (CityId < 1)
            throw new DomainException(DomainErrors.InvalidCenterCityIdRange);
    }

    private void ValidatePhoneNumber()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
            throw new DomainException(DomainErrors.CenterPhoneNumberIsRequired);

        if (PhoneNumber.Length != 11)
            throw new DomainException(DomainErrors.InvalidCenterPhoneNumberLength);

        if (!PhoneNumber.All(char.IsDigit))
            throw new DomainException(DomainErrors.CenterPhoneNumberIsDigit);
    }

    private void FixPhoneNumberFormat()
    {
        if (PhoneNumber.StartsWith("+98"))
            PhoneNumber = $"09{PhoneNumber.Substring(3)}";
    }

}
