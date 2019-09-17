namespace CustomersService.Infra.ExternalServices.Email
{
    public class ValidateEmailRequest
    {
        public ValidateEmailRequest(string name, string document, string email)
        {
            Name = name;
            Document = document;
            Email = email;
        }

        public string Name { get; }
        public string Document { get; }
        public string Email { get; }
    }
}