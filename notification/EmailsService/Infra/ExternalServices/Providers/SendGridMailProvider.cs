using EmailsService.Infra.ExternalServices.Dtos;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using EmailAddress = SendGrid.Helpers.Mail.EmailAddress;

namespace EmailsService.Infra.ExternalServices.Providers
{
    public class SendGridMailProvider : IMailProvider
    {
        private readonly ISendGridClient _client;
        
        public SendGridMailProvider(ISendGridClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<MailResponse> SendAsync(MailRequest request)
        {
            var message = CreateSendGridMessage(request);

            var response = await _client.SendEmailAsync(message);
            
            return new MailResponse { StatusCode = response.StatusCode };
        }

        private static SendGridMessage CreateSendGridMessage(MailRequest request)
        {
            var from = new EmailAddress(request.From.Email, request.From.Name);
            var to = new EmailAddress(request.To.Email, request.To.Name);

            var message = MailHelper.CreateSingleTemplateEmail(from, to, request.Template.Id, request.Template.Data);
            message.AddHeader("notification-message-id", $"{request.MessageId}");

            return message;
        }
    }
}