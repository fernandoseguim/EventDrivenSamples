using System;
using System.Text;

namespace EmailsService.Domain
{
    public class Email
    {
        public Email(string address, string documentNumber)
        {
            Address = address;
            DocumentNumber = documentNumber;
            
            Validated = false;
        }

        public Email() : this(null, null) { }

        public string Address { get; private set; }
        public string DocumentNumber { get; private set; }
        public bool Validated { get; private set; }

        public void Validate(string token)
        {
            var expiration = ExtractTokenData(token);
            Validated = expiration == DateTime.Today && token.Equals(GetToken());
        }

        public string GetToken()
        {
            var bytes = Encoding.UTF8.GetBytes($"{Address}::{DocumentNumber}::{DateTime.Today}");
            return Convert.ToBase64String(bytes);
        }

        private DateTime ExtractTokenData(string token)
        {
            var bytes = Convert.FromBase64String(token);

            var data = Encoding.UTF8.GetString(bytes).Split("::");
            Address = data[0];
            DocumentNumber = data[1];

            DateTime.TryParse(data[2], out var expiration);
            return expiration;
        }
    }
}
