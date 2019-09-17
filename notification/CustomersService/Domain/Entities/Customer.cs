using CustomersService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using CustomersService.Domain.Events;
using EventDrivenSamples.Contracts;

namespace CustomersService.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            Emails = new List<Email>();
            ShippingAddresses = new List<Address>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }

        public IList<Email> Emails { get; }
        public Address BillingAddress { get; private set; }
        public IList<Address> ShippingAddresses { get; }
        
        public Customer Create(Document document, Name name, Address address)
        {
            Id = Guid.NewGuid().ToString();

            Document = document;
            Name = name;
            PendingEvents.Enqueue(new CustomerWasCreated(Id, new { Document, Name }));

            AddBillingAddress(address);

            return this;
        }

        public void AddShippingAddress(Address address)
        {
            if (address is null) throw new ArgumentNullException(nameof(address));

            if (address.IsShippingAddress)
            {
                ShippingAddresses.Add(address);
                PendingEvents.Enqueue(new ShipingAddressWasAdded(Id, new { ShippingAddress = address }));
            }
        }

        public void AddBillingAddress(Address address)
        {
            if (address is null) throw new ArgumentNullException(nameof(address));

            PendingEvents.Enqueue(new BillingAddressWasAdded(Id, new { BillingAddress = address }));
            
            BillingAddress = address;
        }

        public void AddEmail(Email email)
        {
            var exist = Emails.Any(item => item.Equals(email));
            if (exist) { throw new InvalidOperationException("Email already exist"); }
            Emails.Add(email);

            PendingEvents.Enqueue(new EmailWasAdded(Id, new { Email = email }));
        }
        public void ConfirmEmail(Email email)
        {
            var exist = Emails.Any(item => item.Equals(email));
            if(exist)
            {
                Emails.Remove(email);
                Emails.Add(email);
            }
            else
            {
                throw new InvalidOperationException("Email not exist"); 
            }

            PendingEvents.Enqueue(new EmailWasConfirmed(Id, new { Email = email }));
        }
    }
}
