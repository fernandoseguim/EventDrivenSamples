using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CustomersService.Domain.Contracts.Repositories;
using CustomersService.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomersService.Infra.Repositories.CustomerContext
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DynamoDBContext _context;
        private readonly DynamoDBOperationConfig _configuration;
        private readonly ILogger<CustomersRepository> _logger;

        public CustomersRepository(IAmazonDynamoDB dynamoDb, ILogger<CustomersRepository> logger)
        {
            _logger = logger;
            _context = new DynamoDBContext(dynamoDb);
            _configuration = new DynamoDBOperationConfig()
            {
                OverrideTableName = "Customers",
                Conversion = DynamoDBEntryConversion.V2
            };
        }

        public async Task Add(CustomerData customer)
        {
            try
            {
                await _context.SaveAsync(customer, _configuration);
            }
            catch(Exception exception)
            {
                _logger.LogCritical(exception, "Erro ao salvar registro");
                throw;
            }
        }

        public async Task<CustomerData> Get(string document)
        {
            try
            {
                var data = await _context.LoadAsync<CustomerData>(document);

                return data;
            }
            catch(Exception exception)
            {
                _logger.LogCritical(exception, "Erro ao obter registro");
                throw;
            }
        }
    }
}
