using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Password.Validation.Module.Api.Models.Request;
using Password.Validation.Module.Application.Handlers.Interface;
using Password.Validation.Module.Contracts.Command;

namespace Password.Validation.Module.Api.Controllers
{
    [ApiController]
    [Route("api/password")]
    public class PasswordController : ControllerBase
    {       
        private readonly IHandler<ValidateCommand> _handler;

        public PasswordController(IHandler<ValidateCommand> handler)
        {            
            _handler = handler;
        }

        /// <summary>
        /// validate password
        /// </summary>
        /// <param name="request">Request data</param>        
        /// <response code="200">Successful request processing</response>        
        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status200OK)]       
        [HttpPost("validate")]
        public async Task<IActionResult> ValidatePassword([FromBody] ValidateRequest request)
        {
            var command = new ValidateCommand(request.Password);
            return Ok(await _handler.ExecuteAsync(command));            
        }
    }
}
