namespace CustomersService.Domain.Entities
{
    public class Email
    {
        public Email(string address, bool isMain)
        {
            Address = address;
            IsMain = isMain;
        }

        public string Address { get; }
        public bool IsMain { get; }
    }
}