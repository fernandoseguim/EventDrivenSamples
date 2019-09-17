using EasyNetQ;
using EmailsService.Domain;
using EmailsService.Domain.Command;
using EmailsService.Domain.Contracts.Handlers;
using EmailsService.Infra.ExternalServices.Dtos;
using EmailsService.Infra.ExternalServices.Providers;
using EventDrivenSamples.Contracts.Events.Notification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailsService.Application
{
    public class EmailTokenCommandHandler : IEmailTokenCommandHandler
    {
        private readonly IMailProvider _mailProvider;
        private readonly IBus _bus;
        
        public EmailTokenCommandHandler(IMailProvider mailProvider, IBus bus)
        {
            _mailProvider = mailProvider ?? throw new ArgumentNullException(nameof(mailProvider));
            _bus = bus;
        }

        public async Task Handle(CreateEmailTokenCommand command)
        {
            var email = new Email(command.Email, command.Document);
            
            await _mailProvider.SendAsync(new MailRequest(Guid.NewGuid(), new Addressing("no-reply@seguim.me", "Seguim"), new Addressing(command.Email, command.Name), BuildTemplate(command.Name, email)));
        }

        public async Task Handle(ValidateEmailTokenCommand command)
        {
            var email = new Email();
            email.Validate(command.Token);

            if (email.Validated)
            {
                await _bus.PublishAsync<IEmailTokenWasValidated>(new EmailTokenWasValidated { Document = command.Document, Email = email.Address });
            }
            else
            {
                await _bus.PublishAsync<IEmailTokenWasExpired>(new EmailTokenWasExpired{ Document = command.Document, Email = email.Address });
            }
        }

        private static Template BuildTemplate(string name, Email email) =>
            new Template("d-82f9c16fbca745ef8df3d1631f093239", new Dictionary<string, string>
            {
                { "name", name },
                { "link", $"http://localhost:6000/api/v1/emails/{email.DocumentNumber}/validation/{email.GetToken()}" }
            });
    }
}
