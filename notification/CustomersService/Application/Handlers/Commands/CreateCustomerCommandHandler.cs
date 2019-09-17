using CustomersService.Domain.Commands.Requests;
using CustomersService.Domain.Contracts.Handlers;
using CustomersService.Domain.ValueObjects;
using System;
using System.Threading.Tasks;
using CustomersService.Domain.Commands.Responses;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Domain.Entities;
using CustomersService.Infra.ExternalServices.Email;

namespace CustomersService.Application.Handlers
{
    public class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IValidateEmailService _validateEmailService;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository, IValidateEmailService validateEmailService)
        {
            _validateEmailService = validateEmailService ?? throw new ArgumentNullException(nameof(validateEmailService));
            _customersRepository = customersRepository ?? throw new ArgumentNullException(nameof(customersRepository));
        }

        public async Task<ICommandResult> Handle(CreateCustomerCommand command)
        {
            var document = new Document(command.DocumentNumber, DocumentType.CPF);
            var name = new Name(command.FirstName, command.Surname);
            var email = new Email(command.Email);
            var customer = new Customer().Create(document, name, command.Address);

            await _customersRepository.Add(customer);

            var request = new ValidateEmailRequest($"{name}", $"{document}", $"{email}");
            await _validateEmailService.Send(request);

            return new SuccessfulCommandResult("customer was created", command);
        }
    }
}
