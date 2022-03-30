using Password.Validation.Module.Contracts.Command.Contract;
using Password.Validation.Module.Service.Specification;
using System.Threading.Tasks;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Service
{
    public class ValidatePasswordService : IValidatePasswordService
    {
        public async Task<bool> ExecuteAsync(ValueObject.PasswordValueObject password)
        {
            var result = await Task.FromResult<bool>(PasswordValidateSpec.IsValid(password));
            return result;
        }
    }
}
