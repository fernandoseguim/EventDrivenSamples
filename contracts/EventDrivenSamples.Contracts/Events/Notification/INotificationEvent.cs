using System;

namespace EventDrivenSamples.Contracts.Events.Notification
{
    public interface INotificationEvent
    {
        DateTime Timestamp { get; set; }
    }
}