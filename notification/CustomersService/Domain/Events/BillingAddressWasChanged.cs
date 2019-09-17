using System;
using EventDrivenSamples.Contracts;

namespace CustomersService.Domain.Events
{
    public class ShipingAddressWasAdded: IDomainEvent
    {
        public ShipingAddressWasAdded(string aggregatedId, object data)
        {
            AggregatedId = aggregatedId;
            Data = data;

            EventId = Guid.NewGuid().ToString();
            Name = GetType().FullName;
            Timestamp = DateTime.Now;
        }

        public string AggregatedId { get; set; }
        public string EventId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public dynamic Data { get; set; }
    }
}