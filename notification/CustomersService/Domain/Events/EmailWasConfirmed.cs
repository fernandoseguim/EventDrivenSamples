using Amaury.Abstractions;
using System;
using Amaury.MediatR;

namespace CustomersService.Domain.Events
{
    public class EmailWasConfirmed : INotifiableCelebrityEvent
    {
        public EmailWasConfirmed(string aggregatedId, dynamic data)
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