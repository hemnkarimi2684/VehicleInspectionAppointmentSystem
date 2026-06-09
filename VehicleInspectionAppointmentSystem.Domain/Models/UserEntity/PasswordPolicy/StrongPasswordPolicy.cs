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
            throw new ArgumentException("the password cannot be equals with userName");

        if (!password.Any(char.IsUpper))
            throw new PasswordCaseExcption("the password must have one upperCase letter");

        if (!password.Any(char.IsLower))
            throw new PasswordCaseExcption("the password must have one LowerCase letter");

        if (!password.Any(char.IsDigit))
            throw new PasswordMissingDigitException("the password must have one digit at least");

        bool hasSymbol = false;

        foreach (char c in password)
        {
            if (_symbols.Contains(c))
                hasSymbol = true;
        }

        if (!hasSymbol)
            throw new PasswordSymbolException("the password must have one symbol at least");
    }
}
