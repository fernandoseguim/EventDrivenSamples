using CustomersService.Domain.ValueObjects;

namespace CustomersService.Domain.Commands.Requests
{
    public class CreateCustomerCommand
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DocumentNumber { get; set; }

        public DocumentType DocumentType { get; set; }
        public Address Address { get; set; }
    }
}
