using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomersService.Infra.ExternalServices.Email
{
    public class ValidateEmailService : IValidateEmailService
    {
        private readonly HttpClient _httpClient;

        public ValidateEmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Send(ValidateEmailRequest request)
        {
            var message = new HttpRequestMessage
            {
                Content =new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress, "emails/validation")
            };

            await _httpClient.SendAsync(message);
        }
    }
}