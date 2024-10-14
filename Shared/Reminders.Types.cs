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

    public enum Channel
    {
        EmailMessage,
        MobileMessage,
        Notification
    }
}
