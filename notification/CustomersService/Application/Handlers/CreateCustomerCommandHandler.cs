using System;
using System.Threading.Tasks;
using CustomersService.Domain.Commands.Requests;
using CustomersService.Domain.Contracts.Handlers;

namespace CustomersService.Application.Handlers
{
    public class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
    {
        public Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
