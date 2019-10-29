using CustomersService.Domain.Contracts.Handlers.Events;
using EventDrivenSamples.Contracts.Events.Notification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Domain.Entities;
using CustomersService.Domain.ValueObjects;

namespace CustomersService.Application.Handlers.Events
{
    public class EmailTokenWasValidatedHandler : IEmailTokenWasValidatedHandler
    {
        private readonly ICustomersRepository _customersRepository;

        public EmailTokenWasValidatedHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task Handle(IEmailTokenWasValidated @event)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            ///var data = await _customersRepository.Get(@event.Document);
            
            //if (data is null) throw new InvalidOperationException();
            
            //var customer = new Customer(new Document(data.DocumentNumber, DocumentType.CPF));
            //customer.ConfirmEmail(new Email(@event.Email, true));
            
            await Console.Out.WriteLineAsync($"Email { @event.Email } foi validado com sucesso para o documento { @event.Document }!");
            Console.ResetColor();
        }
    }
}
