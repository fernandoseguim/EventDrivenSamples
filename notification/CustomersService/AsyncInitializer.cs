using AspNetCore.AsyncInitialization;
using CustomersService.Infra.Repositories;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace CustomersService
{
    [ExcludeFromCodeCoverage]
    public class AsyncInitializer : IAsyncInitializer
    {
        private readonly IRepositoryConfiguration _repositoryConfiguration;

        public AsyncInitializer(IRepositoryConfiguration repositoryConfiguration) => _repositoryConfiguration = repositoryConfiguration;

        public async Task InitializeAsync() => await _repositoryConfiguration.ConfigureAsync();
    }
}