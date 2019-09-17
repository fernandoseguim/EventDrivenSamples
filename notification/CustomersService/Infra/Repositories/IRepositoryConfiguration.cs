using System.Threading.Tasks;
using Amazon.DynamoDBv2;

namespace CustomersService.Infra.Repositories
{
    public interface IRepositoryConfiguration
    {
        IAmazonDynamoDB DynamoDb { get; }

        string TableName { get; }

        Task ConfigureAsync();
    }
}