using System.Threading.Tasks;
using EventDrivenSamples.Contracts.Events.Notification;

namespace CustomersService.Domain.Contracts.Handlers.Events
{
    public interface IEmailTokenWasValidatedHandler
    {
        Task Handle(IEmailTokenWasValidated @event);
    }
}
