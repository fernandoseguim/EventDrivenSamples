using CustomersService.Domain.Contracts.Handlers.Events;
using EasyNetQ;
using EventDrivenSamples.Contracts.Events.Notification;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CustomersService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBus _bus;
        private readonly IEmailTokenWasValidatedHandler _emailWasConfirmedHandler;
        private readonly IEmailTokenWasExpiredHandler _emailTokenWasExpiredHandler;

        public Worker(ILogger<Worker> logger, IBus bus, IEmailTokenWasValidatedHandler emailWasConfirmedHandler, IEmailTokenWasExpiredHandler emailTokenWasExpiredHandler)
        {
            _logger = logger;
            _bus = bus;
            _emailWasConfirmedHandler = emailWasConfirmedHandler;
            _emailTokenWasExpiredHandler = emailTokenWasExpiredHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            => await Task.Run(RegisterConsumers, stoppingToken);

        private void RegisterConsumers()
        {
            _bus.SubscribeAsync<IEmailTokenWasValidated>("EventDrivenSamples.CustomersService", _emailWasConfirmedHandler.Handle);
            _bus.SubscribeAsync<IEmailTokenWasExpired>("EventDrivenSamples.CustomersService", _emailTokenWasExpiredHandler.Handle);
        }
    }
}
