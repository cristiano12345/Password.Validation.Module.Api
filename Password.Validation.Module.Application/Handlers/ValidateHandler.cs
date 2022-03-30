using Password.Validation.Module.Application.Handlers.Interface;
using Password.Validation.Module.Contracts.Command;
using Password.Validation.Module.Contracts.Command.Contract;
using System.Threading.Tasks;

namespace Password.Validation.Module.Application.Handlers
{
    public class ValidateHandler : IHandler<ValidateCommand>
    {
        protected IValidatePasswordService validatePassword;
        public ValidateHandler(IValidatePasswordService validatePassword)
        {
            this.validatePassword = validatePassword;
        }

        public async Task<ICommandResult> ExecuteAsync(ValidateCommand command)
        {            
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false);            

            return new GenericCommandResult(await validatePassword.ExecuteAsync(command.Password));
        }
    }
}
