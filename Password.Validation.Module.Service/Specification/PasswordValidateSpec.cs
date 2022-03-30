using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Service.Specification
{
    public static class PasswordValidateSpec
    {
        public static bool IsValid(ValueObject.PasswordValueObject password)
        {
            return new PasswordValidateIsNotRepeatedCharSpec()
                .And(new PasswordValidateContainsCapitalLettersSpec())
                .And(new PasswordValidateContainsNumbersSpec())
                .And(new PasswordValidateContainsSmallLettersSpec())               
                .And(new PasswordValidateContainsSpecialCharactersSpec())
                .And(new PasswordValidateContainsLengthSpec())
                .IsSatisfiedBy(password);
        }
    }
}
