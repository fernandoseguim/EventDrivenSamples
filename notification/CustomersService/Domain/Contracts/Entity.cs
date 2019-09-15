using System;

namespace CustomersService.Domain.Contracts
{
    public abstract class Entity
    {
        protected Guid Id { get; set; }
    }
}