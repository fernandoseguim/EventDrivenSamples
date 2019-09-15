using System;
using System.Collections.Generic;
using CustomersService.Domain.Contracts;
using CustomersService.Domain.ValueObjects;

namespace CustomersService.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Document document, Name name, Email email, Address address)
        {
            Id = Guid.NewGuid();

            Document = document;
            Name = name;
            Emails = new List<Email> { email };
            Addresses = new List<Address>{ address };
        }

        public Name Name { get; }
        public Document Document { get; }

        public IList<Email> Emails { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
