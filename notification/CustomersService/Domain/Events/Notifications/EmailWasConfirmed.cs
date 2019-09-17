using EventDrivenSamples.Contracts.Events.Notification;

namespace CustomersService.Domain.Events.Notifications
{
    public class EmailWasConfirmed : IEmailTokenWasValidated
    {
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
