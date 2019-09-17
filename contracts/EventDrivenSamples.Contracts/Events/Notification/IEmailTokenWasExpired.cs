namespace EventDrivenSamples.Contracts.Events.Notification
{
    public interface IEmailTokenWasExpired
    {
        string Document { get; }
        string Email { get; }
    }
}
