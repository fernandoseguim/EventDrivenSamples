using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;
using EventDrivenSamples.Contracts.Events.StateTransfer;
using MediatR;
using CustomerWasCreated = CustomersService.Domain.Events.CustomerWasCreated;

namespace CustomersService.Application.Handlers.Events.Publishers
{
    public class CustomerWasCreatedPublisher : INotificationHandler<CustomerWasCreated>
    {
        private readonly IAdvancedBus _bus;

        public CustomerWasCreatedPublisher(IAdvancedBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(CustomerWasCreated notification, CancellationToken cancellationToken)
        {
            var message = new Message<ICustomerWasCreated>(notification);

            var exchange = _bus.ExchangeDeclare("customer-was-created", ExchangeType.Fanout);
            var queue = _bus.QueueDeclare("customer-was-created");
            _bus.Bind(exchange, queue, "");

            await _bus.PublishAsync<ICustomerWasCreated>(exchange, "", true, message); 
        }
    }
}
