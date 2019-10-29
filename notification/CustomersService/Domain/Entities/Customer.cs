using Amaury.MediatR;
using CustomersService.Domain.Events;
using CustomersService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersService.Domain.Entities
{
    public class Customer : INotifiableCelebrity<Customer>
    {
        public Customer()
        {
            Emails = new List<Email>();
            PendingEvents = new Queue<INotifiableCelebrityEvent>();
        }

        public Customer(Document document)
        {
            Emails = new List<Email>();
            PendingEvents = new Queue<INotifiableCelebrityEvent>();
        }

        public string AggregatedId { get; set; }
        public Queue<INotifiableCelebrityEvent> PendingEvents { get; }


        public Name Name { get; private set; }
        public Document Document { get; private set; }

        public IList<Email> Emails { get; }
        public Address BillingAddress { get; private set; }
        
        public Customer Create(Document document, Name name, Address address)
        {
            AggregatedId = Guid.NewGuid().ToString();

            Document = document;
            Name = name;
            BillingAddress = address;
            PendingEvents.Enqueue(new CustomerWasCreated(AggregatedId, new { Document, Name, BillingAddress }));

            return this;
        }

        public void AddBillingAddress(Address address)
        {
            if (address is null) throw new ArgumentNullException(nameof(address));

            PendingEvents.Enqueue(new BillingAddressWasAdded(AggregatedId, new { BillingAddress = address }));
            
            BillingAddress = address;
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

            PendingEvents.Enqueue(new EmailWasConfirmed(AggregatedId, new { Email = email }));
        }
    }
}
