using MediatR;


namespace EventSenderFuncApp.Infrastructure.NotificationManagement
{
    public class EventNotification : INotification
    {
        public string Message { get; set; }
    }
}
