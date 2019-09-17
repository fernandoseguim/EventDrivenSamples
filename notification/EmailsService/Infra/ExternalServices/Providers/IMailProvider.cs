using System.Threading.Tasks;
using EmailsService.Infra.ExternalServices.Dtos;

namespace EmailsService.Infra.ExternalServices.Providers
{
    public interface IMailProvider
    {
        Task<MailResponse> SendAsync(MailRequest request);
    }
}