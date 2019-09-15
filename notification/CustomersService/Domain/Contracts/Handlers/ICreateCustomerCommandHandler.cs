using System.Threading.Tasks;
using CustomersService.Domain.Commands.Requests;

namespace CustomersService.Domain.Contracts.Handlers
{
    public interface ICreateCustomerCommandHandler
    {
        Task<ICommandResult> Handle(CreateCustomerCommand command);
    }
}
