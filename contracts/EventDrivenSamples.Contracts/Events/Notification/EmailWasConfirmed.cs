namespace EventDrivenSamples.Contracts.Events.Notification
{
    public class EmailTokenWasValidated : IEmailTokenWasValidated
    {
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
