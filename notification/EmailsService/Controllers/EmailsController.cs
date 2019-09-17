using System;
using System.Threading.Tasks;
using EmailsService.Domain.Command;
using EmailsService.Domain.Contracts.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace EmailsService.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailTokenCommandHandler _validateEmailCommandHandler;

        public EmailsController(IEmailTokenCommandHandler validateEmailCommandHandler)
        {
            _validateEmailCommandHandler = validateEmailCommandHandler ?? throw new ArgumentNullException(nameof(validateEmailCommandHandler));
        }

        // GET api/emails/validations
        [HttpGet("{document}/validation/{token}")]
        public async Task<IActionResult> Validate([FromRoute] string document, [FromRoute] string token)
        {
            await _validateEmailCommandHandler.Handle(new ValidateEmailTokenCommand { Document = document, Token = token });
            return Accepted();
        }

        [HttpPost("validation")]
        public async Task<IActionResult> Post([FromBody] CreateEmailTokenCommand command)
        {
            await _validateEmailCommandHandler.Handle(command);
            return Accepted();
        }
    }
}
