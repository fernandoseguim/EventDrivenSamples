namespace EventDrivenSamples.Contracts.Events.Notification
{
    public class EmailTokenWasExpired : IEmailTokenWasExpired
    {
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
