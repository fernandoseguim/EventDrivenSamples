using System.Net;

namespace EmailsService.Infra.ExternalServices.Dtos
{
    public class MailResponse
    {
        public HttpStatusCode StatusCode { get; set; }
    }
}
