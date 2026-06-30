using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.PasswordPolicy.PasswordExceptions;

namespace VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.PasswordPolicy;

public static class StrongPasswordPolicy
{
    private static string _symbols = "!@#$%^&*";

    public static void Validate(string userName,string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return;

        if (password.Length < 8)
            throw new PasswordTooShortExcption();

        if (userName.Equals(password, StringComparison.InvariantCultureIgnoreCase))
            throw new DomainException(DomainErrors.PasswordCannotEqualsWithUserName);

        if (!password.Any(char.IsUpper))
            throw new DomainException(DomainErrors.PasswordDontHaveAtLeastUpperCaseLetter);

        if (!password.Any(char.IsLower))
            throw new DomainException(DomainErrors.PasswordDontHaveAtLeastLowerCaseLetter);

        if (!password.Any(char.IsDigit))
            throw new DomainException(DomainErrors.PasswordDontHaveAtLeastOneDigit);

        bool hasSymbol = false;

        foreach (char c in password)
        {
            if (_symbols.Contains(c))
                hasSymbol = true;
        }

        if (!hasSymbol)
            throw new DomainException(DomainErrors.PasswordDontHaveAtLeastOneSymbol);
    }
}
