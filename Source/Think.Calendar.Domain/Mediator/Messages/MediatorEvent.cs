using MediatR;

namespace Think.Calendar.Domain.Mediator.Messages
{
    public class MediatorEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        protected MediatorEvent()
        {
            Timestamp = DateTime.Now;
        }
    }
}
