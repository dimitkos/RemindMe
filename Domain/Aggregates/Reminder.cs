using Shared;

namespace Domain.Aggregates
{
    public class Reminder
    {
        public long Id { get; }
        public string Message { get; private set; }
        public Channel Channel { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime NotifyAt { get; private set; }
        public long UserId { get; }

        public Reminder(long id, string message, Channel channel, DateTime createdAt, DateTime notifyAt, long userId)
        {
            Id = id;
            Message = message;
            Channel = channel;
            CreatedAt = createdAt;
            NotifyAt = notifyAt;
            UserId = userId;
        }

        public static Reminder CreateReminder(int id, string message, Channel channel, DateTime notifyAt, long userId)
        {
            return new Reminder(
                id: id,
                message: message,
                channel: channel,
                createdAt: DateTime.UtcNow,
                notifyAt: notifyAt,
                userId: userId);
        }

        public Reminder UpdateReminder(string message, Channel channel, DateTime notifyAt)
        {
            Message = message;
            Channel = channel;
            NotifyAt = notifyAt;

            return this;
        }
    }
}
