using System;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Domain.Events;
using CustomersService.Infra.Repositories.CustomerContext;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CustomersService.Application.Handlers.Events
{
    public class CustomerWasCreatedHandler : INotificationHandler<CustomerWasCreated>
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerWasCreatedHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task Handle(CustomerWasCreated notification, CancellationToken cancellationToken)
        {
            var data = new CustomerData
            {
                DocumentNumber = $"{notification.Data.Document}",
                Name = $"{notification.Data.Name}",
                BillingAddress = JsonConvert.SerializeObject(notification.Data.BillingAddress)
            };
            
            await Console.Out.WriteLineAsync($"{notification.Data.BillingAddress}");
            await _customersRepository.Add(data);
        }
    }
}
