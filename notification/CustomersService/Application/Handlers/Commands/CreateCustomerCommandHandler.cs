using Amaury.MediatR.Bus;
using CustomersService.Domain.Commands.Requests;
using CustomersService.Domain.Commands.Responses;
using CustomersService.Domain.Contracts.Handlers;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Domain.Entities;
using CustomersService.Domain.ValueObjects;
using CustomersService.Infra.ExternalServices.Email;
using System;
using System.Threading.Tasks;

namespace CustomersService.Application.Handlers.Commands
{
    public class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IValidateEmailService _validateEmailService;
        private readonly INotifiableCelebrityEventsBus _bus;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository, IValidateEmailService validateEmailService, INotifiableCelebrityEventsBus bus)
        {
            _validateEmailService = validateEmailService ?? throw new ArgumentNullException(nameof(validateEmailService));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _customersRepository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));
        }

        public async Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            var document = new Document(command.DocumentNumber, DocumentType.CPF);
            var name = new Name(command.FirstName, command.Surname);
            var email = new Email(command.Email);
            var customer = new Customer().Create(document, name, command.Address);

            var request = new ValidateEmailRequest($"{name}", $"{document}", $"{email}");
            await _validateEmailService.Send(request);

            await _bus.RaiseEvents(customer.PendingEvents);

            return new SuccessfulCommandResult("customer was created", command);
        }
    }
}
