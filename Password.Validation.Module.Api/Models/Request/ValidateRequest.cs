using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Password.Validation.Module.Api.Models.Request
{
    /// <summary>
    /// Validate password request model
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ValidateRequest
    {
        /// <summary>
        /// Password to validade
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
