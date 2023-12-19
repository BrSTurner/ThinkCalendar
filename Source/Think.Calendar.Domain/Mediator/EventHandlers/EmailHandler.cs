using MediatR;
using System.Text;
using Think.Calendar.Domain.Mediator.Notifications;

namespace Think.Calendar.Domain.Mediator.EventHandlers
{
    public class EmailHandler : INotificationHandler<CalendarEventCreatedNotification>,
        INotificationHandler<CalendarEventUpdatedNotification>,
        INotificationHandler<CalendarEventDeletedNotification>
    {
        public Task Handle(CalendarEventCreatedNotification notification, CancellationToken cancellationToken)
        {
            ///...Send Email to formalize
           
            var emailBody = new StringBuilder("Hello");

            emailBody.AppendLine($"You have been invited to attend the event {notification.Title}");
            emailBody.AppendLine($"\n{notification.Description}");
            emailBody.AppendLine($"\nThe event is going to happen in the following location: {notification.Location}");
            emailBody.AppendLine($"\nStarting at {notification.StartDate} and finishing at {notification.EndDate}");
            emailBody.AppendLine($"\nSee you there!");

            return Task.CompletedTask;
        }

        public Task Handle(CalendarEventUpdatedNotification notification, CancellationToken cancellationToken)
        {
            ///...Send Email to formalize

            var emailBody = new StringBuilder("Hello");

            emailBody.AppendLine($"An event you have been invited just changed");
            emailBody.AppendLine($"\n Previous Title: {notification.PreviousTitle} -> {notification.Title}");
            emailBody.AppendLine($"\n Previous Description: {notification.PreviousDescription} -> {notification.Description}");
            emailBody.AppendLine($"\n Previous Location: {notification.PreviousLocation} -> {notification.Location}");
            emailBody.AppendLine($"\n Previous Start Date: {notification.PreviousStartDate} -> {notification.StartDate}");
            emailBody.AppendLine($"\n Previous End Date: {notification.PreviousEndDate} -> {notification.EndDate}");
            emailBody.AppendLine($"\nStay tunned for more information, see you there!");

            return Task.CompletedTask;
        }

        public Task Handle(CalendarEventDeletedNotification notification, CancellationToken cancellationToken)
        {
            ///...Send Email to formalize

            var emailBody = new StringBuilder("Hello");

            emailBody.AppendLine($"An event you have been invited has been cancelled");
            emailBody.AppendLine($"\n Title: {notification.Title}");
            emailBody.AppendLine($"\n Location: {notification.Location}");
            emailBody.AppendLine($"\n Start Date: {notification.StartDate.ToString()}");

            return Task.CompletedTask;
        }
    }
}
