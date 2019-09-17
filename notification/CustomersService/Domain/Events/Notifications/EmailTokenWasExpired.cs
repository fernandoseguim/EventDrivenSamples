using EventDrivenSamples.Contracts.Events.Notification;

namespace CustomersService.Domain.Events.Notifications
{
    public class EmailTokenWasExpired : IEmailTokenWasExpired
    {
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
