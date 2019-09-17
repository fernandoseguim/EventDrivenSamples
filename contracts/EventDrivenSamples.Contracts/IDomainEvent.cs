using System;

namespace EventDrivenSamples.Contracts
{
    public interface IDomainEvent
    {
        string AggregatedId { get; set; }
        string EventId { get; set; }
        string Name { get; set; }
        DateTime Timestamp { get; set; }
        dynamic Data { get; set; }
    }
}
