using System.Threading.Tasks;

namespace Password.Validation.Module.Contracts.Command.Contract
{
    public interface IValidatePasswordService
    {
        Task<bool> ExecuteAsync(ValueObject.PasswordValueObject password);
    }
}
