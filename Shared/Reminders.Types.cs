namespace Shared
{
    public class AddReminderPayload
    {
        public int UserId { get; }
        public string Message { get; }
        public Channel Channel { get; }
        public DateTime NotifyAt { get; }

        public AddReminderPayload(int userId, string message, Channel channel, DateTime notifyAt)
        {
            UserId = userId;
            Message = message;
            Channel = channel;
            NotifyAt = notifyAt;
        }
    }

    public class UpdateReminderPayload
    {
        public int UserId { get; }
        public int ReminderId { get; }
        public string Message { get; }
        public Channel Channel { get; }
        public DateTime NotifyAt { get; }

        public UpdateReminderPayload(int userId, int reminderId, string message, Channel channel, DateTime notifyAt)
        {
            UserId = userId;
            ReminderId = reminderId;
            Message = message;
            Channel = channel;
            NotifyAt = notifyAt;
        }
    }

    public class RemoveReminderPayload
    {
        public int UserId { get; }
        public int ReminderId { get; }

        public RemoveReminderPayload(int userId, int reminderId)
        {
            UserId = userId;
            ReminderId = reminderId;
        }
    }

    public class Reminder
    {
        public long Id { get; }
        public string Message { get; }
        public Channel Channel { get; }
        public DateTime CreatedAt { get; }
        public DateTime NotifyAt { get; }

        public Reminder(long id, string message, Channel channel, DateTime createdAt, DateTime notifyAt)
        {
            Id = id;
            Message = message;
            Channel = channel;
            CreatedAt = createdAt;
            NotifyAt = notifyAt;
        }
    }

    public enum Channel
    {
        EmailMessage,
        MobileMessage,
        Notification
    }
}
