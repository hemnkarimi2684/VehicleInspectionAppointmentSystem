using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.PasswordPolicy;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Entity;

// کاربر
public class User : BaseEntity
{
    private User() { }

    public User(string? firstName, string? lastName, string? nationalCode, string? fatherName, string? password, string phoneNumber, DateTime? birthDate)
    {
        //Fill Properties
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        FatherName = fatherName;
        _password = password;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;

        //Methods
        FixPhoneNumberFormat();
        SetRoleByDefault();
        Validate();
        SetUserNameByDefault();
    }

    public string? FirstName { get; private set; }

    public string? LastName { get; private set; }

    public string? NationalCode { get; private set; }

    public string? FatherName { get; private set; }

    //Has Default Value
    public string UserName { get; private set; }

    private string? _password;

    public string PhoneNumber { get; private set; }

    public DateTime? BirthDate { get; private set; }

    public Role Role { get; private set; }

    //Navigation Properties
    public virtual ICollection<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

    protected override void Validate()
    {
        if ((!string.IsNullOrWhiteSpace(FirstName) && FirstName?.Length > 120 || FirstName?.Length < 0) ||
            (!string.IsNullOrWhiteSpace(LastName) && LastName?.Length > 120 || LastName?.Length < 0))
            throw new DomainException(DomainErrors.InvalidUserFirstNameOrLastNameLength);

        if (!string.IsNullOrWhiteSpace(FatherName) && FatherName?.Length > 120 || FatherName?.Length < 0)
            throw new DomainException(DomainErrors.InvalidUserFatherNameLength);

        ValidatePhoneNumber();

        if (BirthDate is not null)
        {
            if (BirthDate.Value > DateTime.UtcNow.AddYears(-18))
                throw new DomainException(DomainErrors.InvalidUserBirthDateRange);
        }

        if (NationalCode is not null)
            ValidateNationalCode(NationalCode);
    }

    private void ValidatePhoneNumber()
    {
        if (string.IsNullOrWhiteSpace(PhoneNumber))
            throw new DomainException(DomainErrors.UserPhoneNumberIsRequired);

        if (PhoneNumber.Length != 11)
            throw new DomainException(DomainErrors.InvalidUserPhoneNumberLength);

        if (!PhoneNumber.All(char.IsDigit))
            throw new DomainException(DomainErrors.UserPhoneNumberIsDigit);
    }

    private void ValidateUserName(string userName)
    {
        if (string.IsNullOrWhiteSpace(UserName))
            throw new DomainException(DomainErrors.UserNameIsRequired);

        if (userName.Length < 3 || userName.Length > 20)
            throw new DomainException(DomainErrors.InvalidUserNameLength);

        if (userName.Any(char.IsSymbol))
            throw new DomainException(DomainErrors.UserNameHasSymbol);
    }

    private void SetUserNameByDefault() => UserName = PhoneNumber;

    private void ValidateNationalCode(string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            throw new DomainException(DomainErrors.UserNationalCodeIsRequired);

        if (nationalCode.Length != 10)
            throw new DomainException(DomainErrors.InvalidUserNationalCodeLength);

        if (!nationalCode.All(char.IsDigit))
            throw new DomainException(DomainErrors.UserNationalCodeDontHaveDigit);
    }

    private void FixPhoneNumberFormat()
    {
        if (PhoneNumber.StartsWith("+98"))
            PhoneNumber = $"09{PhoneNumber.Substring(3)}";
    }

    private void SetRoleByDefault() => Role = Role.User;

    public void UpdateNationalCode(string nationalCode)
    {
        ValidateNationalCode(nationalCode);

        NationalCode = nationalCode;
    }

    public void UpdatePasswordAndUserName(string userName, string password)
    {
        StrongPasswordPolicy.Validate(userName, password);
        ValidateUserName(userName); 

        _password = password;
        UserName = userName;
    }

    public void UpdateBirthDate(DateTime birthDate) => BirthDate = birthDate;

    public void UpdateUserInfo(string firstName, string lastName, string nationalCode, string fatherName)
    {
        if ((string.IsNullOrWhiteSpace(firstName) && firstName.Length > 120 || firstName.Length < 0) ||
            (string.IsNullOrWhiteSpace(lastName) && lastName.Length > 120 || lastName.Length < 0))
            throw new DomainException(DomainErrors.InvalidUserFirstNameOrLastNameLength);

        if (string.IsNullOrWhiteSpace(fatherName) && fatherName.Length > 120 || fatherName.Length < 0)
            throw new DomainException(DomainErrors.InvalidUserFatherNameLength);

        ValidateNationalCode(nationalCode);

        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        FatherName = fatherName;
    }

    public bool IsPasswordRight(string password) => _password == password;

    public bool IsPasswordNotNull() => _password != null;


}
