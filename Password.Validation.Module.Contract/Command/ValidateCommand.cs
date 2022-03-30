using Password.Validation.Module.Contracts.Command.Contract;

namespace Password.Validation.Module.Contracts.Command
{
    public class ValidateCommand : CommandBase, ICommand
    {
        public bool Validate()
        {
            return Password.Verified;                
        }

        public ValidateCommand(string password)
        {
            Password = new ValueObject.PasswordValueObject(password);
            Password.Verify(Password.VerificationCode);
            IsValid = Validate();                         
        }

        public ValueObject.PasswordValueObject Password { get; private set; }        

    }
}
