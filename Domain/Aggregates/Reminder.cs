namespace Domain.Aggregates
{
    public class Reminder
    {
        public int Id { get; }
        public string Message { get; private set; }
        public Channel Channel { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime NotifyAt { get; private set; }

        public Reminder(int id, string message, Channel channel, DateTime createdAt, DateTime notifyAt)
        {
            Id = id;
            Message = message;
            Channel = channel;
            CreatedAt = createdAt;
            NotifyAt = notifyAt;
        }

        public static Reminder CreateReminder(int id, string message, Channel channel, DateTime notifyAt)
        {
            return new Reminder(
                id: id,
                message: message,
                channel: channel,
                createdAt: DateTime.UtcNow,
                notifyAt: notifyAt);
        }

        public Reminder UpdateMessage(string message)
        {
            Message = message;

            return this;
        }

        public Reminder UpdateChannel(Channel channel)
        {
            Channel = channel;

            return this;
        }

        public Reminder UpdateNotifyAt(DateTime notifyAt)
        {
            NotifyAt = notifyAt;

            return this;
        }
    }

#warning move this to shared
    public enum Channel
    {
        EmailMessage,
        MobileMessage,
        Notification
    }
}
