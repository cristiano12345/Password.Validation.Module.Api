using Password.Validation.Module.Contracts.Command.Contract;
using System.Threading.Tasks;

namespace Password.Validation.Module.Application.Handlers.Interface
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> ExecuteAsync(T command);
    }
}
