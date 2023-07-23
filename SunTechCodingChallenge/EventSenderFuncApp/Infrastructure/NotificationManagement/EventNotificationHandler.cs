using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventSenderFuncApp.Infrastructure.NotificationManagement
{
    public class EventNotificationHandler : INotificationHandler<EventNotification>
    {
        public Task Handle(EventNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{notification.Message}");
           
            return Task.CompletedTask;
        }
    }
}
