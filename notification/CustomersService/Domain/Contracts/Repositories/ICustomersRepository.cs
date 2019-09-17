using System.Threading.Tasks;
using CustomersService.Domain.Entities;

namespace CustomersService.Domain.Contracts.Repositories
{
    public interface ICustomersRepository
    {
        Task Add(Customer customer);
    }
}
