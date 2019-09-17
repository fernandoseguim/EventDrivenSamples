namespace EventDrivenSamples.Contracts.Events.Notification
{
    public interface IEmailTokenWasValidated
    {
        string Document { get; set; }
        string Email { get; set; }
    }
}
