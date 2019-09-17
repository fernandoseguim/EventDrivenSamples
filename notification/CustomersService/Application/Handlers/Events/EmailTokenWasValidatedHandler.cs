using CustomersService.Domain.Contracts.Handlers.Events;
using EventDrivenSamples.Contracts.Events.Notification;
using System;
using System.Threading.Tasks;

namespace CustomersService.Application.Handlers.Events
{
    public class EmailTokenWasValidatedHandler : IEmailTokenWasValidatedHandler
    {
        public async Task Handle(IEmailTokenWasValidated @event)
        {
            await Console.Out.WriteLineAsync("Deu bom!");
        }
    }
}
