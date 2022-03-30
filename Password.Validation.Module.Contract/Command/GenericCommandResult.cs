using Password.Validation.Module.Contracts.Command.Contract;

namespace Password.Validation.Module.Contracts.Command
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }

        public GenericCommandResult(bool password)
        {
            Password = password;           
        }

        public bool Password { get; set; }      
    }
}
