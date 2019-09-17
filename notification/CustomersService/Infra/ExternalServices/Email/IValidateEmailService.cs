using System.Threading.Tasks;

namespace CustomersService.Infra.ExternalServices.Email
{
    public interface IValidateEmailService
    {
        Task Send(ValidateEmailRequest request);
    }
}
