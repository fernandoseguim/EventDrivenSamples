using System;
using System.Threading.Tasks;
using CustomersService.Domain.Commands.Requests;
using CustomersService.Domain.Contracts.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CustomersService.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICreateCustomerCommandHandler _createCustomerCommandHandler;

        public CustomersController(ICreateCustomerCommandHandler createCustomerCommandHandler)
        {
            _createCustomerCommandHandler = createCustomerCommandHandler ?? throw new ArgumentNullException(nameof(createCustomerCommandHandler));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            var result = await _createCustomerCommandHandler.Handle(command);

            return StatusCode((int)result.StatusCode, result.Data);
        }
    }
}
