using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace CustomersService.Infra.Repositories.CustomerContext
{
    public class CustomersRepositoryConfiguration : IRepositoryConfiguration
    {
        public CustomersRepositoryConfiguration(IAmazonDynamoDB dynamoDb)
        {
            DynamoDb = dynamoDb;
            TableName = "Customers";
        }

        public IAmazonDynamoDB DynamoDb { get; }

        public string TableName { get; }

        public async Task ConfigureAsync()
        {
            var request = new CreateTableRequest
            {
                TableName = TableName,
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition("Document", ScalarAttributeType.S)
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement("Document", KeyType.HASH)
                },
                ProvisionedThroughput = new ProvisionedThroughput(10, 5),
            };

            await CreateIfNotExist(request);
        }

        private async Task<bool> TableExist()
        {
            var tables = await DynamoDb.ListTablesAsync();
            var existTable = tables.TableNames.Contains(TableName);
            return existTable;
        }

        private async Task CreateIfNotExist(CreateTableRequest request)
        {
            if (await TableExist()) { return; }

            await DynamoDb.CreateTableAsync(request);
        }
    }
}
