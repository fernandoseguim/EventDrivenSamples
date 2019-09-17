using CustomersService.Domain.Contracts.Handlers.Events;
using EventDrivenSamples.Contracts.Events.Notification;
using System;
using System.Threading.Tasks;

namespace CustomersService.Application.Handlers.Events
{
    public class EmailTokenWasExpiredHandler : IEmailTokenWasExpiredHandler
    {
        public async Task Handle(IEmailTokenWasExpired @event)
        {
            await Console.Out.WriteLineAsync("Deu ruim!");
        }
    }
}
