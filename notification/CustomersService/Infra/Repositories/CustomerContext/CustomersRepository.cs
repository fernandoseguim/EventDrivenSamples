using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Domain.Entities;

namespace CustomersService.Infra.Repositories.CustomerContext
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DynamoDBContext _context;
        private readonly DynamoDBOperationConfig _configuration;

        public CustomersRepository(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContext(dynamoDb);
            _configuration = new DynamoDBOperationConfig()
            {
                OverrideTableName = "Customers",
                Conversion = DynamoDBEntryConversion.V2
            };
        }

        public async Task Add(Customer customer)
        {
            var data = new CustomerData
            {
                DocumentNumber = $"{customer.Document}",
                Name = $"{customer.Name}",
                BillingAddresses = customer.BillingAddress.ToJson()
            };

            foreach (var email in customer.Emails)
            {
                data.Emails.Add(email.ToJson());
            }

            foreach (var address in customer.ShippingAddresses)
            {
                data.ShippingAddresses.Add(address.ToJson());
            }

            await _context.SaveAsync(data, _configuration);
        }
    }
}
