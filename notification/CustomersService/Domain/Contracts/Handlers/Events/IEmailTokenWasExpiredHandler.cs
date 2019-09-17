using EventDrivenSamples.Contracts.Events.Notification;
using System.Threading.Tasks;

namespace CustomersService.Domain.Contracts.Handlers.Events
{
    public interface IEmailTokenWasExpiredHandler
    {
        Task Handle(IEmailTokenWasExpired @event);
    }
}
