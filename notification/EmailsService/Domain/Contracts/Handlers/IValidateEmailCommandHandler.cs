using System.Threading.Tasks;
using EmailsService.Domain.Command;

namespace EmailsService.Domain.Contracts.Handlers
{
    public interface IEmailTokenCommandHandler
    {
        Task Handle(CreateEmailTokenCommand command);
        Task Handle(ValidateEmailTokenCommand command);
    }
}
