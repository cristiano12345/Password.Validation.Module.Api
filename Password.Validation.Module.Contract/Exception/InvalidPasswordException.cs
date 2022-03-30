using System;

namespace Password.Validation.Module.Contracts.Exception
{
    /// <summary>
    /// Apolice não está apta para ser eetuado o cancelamento
    /// </summary>
    public class InvalidPasswordException : ApplicationException
    {
        /// <inheritdoc />
        public InvalidPasswordException() : base($"Invalid Password")
        {
        }
    }
}
