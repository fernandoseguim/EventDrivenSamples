using CustomersService.Infra.Repositories.CustomerContext;
using System.Threading.Tasks;

namespace CustomersService.Domain.Contracts.Repositories
{
    public interface ICustomersRepository
    {
        Task Add(CustomerData customer);

        Task<CustomerData> Get(string document);
    }

}
