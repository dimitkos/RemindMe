namespace Domain.Aggregates
{
    public class User
    {
        public int Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public DateTime RegisteredAt { get; }
        public List<Reminder> Reminders { get; }

        public User(int id, string firstname, string lastname, string email, string mobile, DateTime registeredAt, List<Reminder> reminders)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Mobile = mobile;
            RegisteredAt = registeredAt;
            Reminders = reminders;
        }

        public static User CreateUser(int id, string firstname, string lastname, string email, string mobile)
        {
            return new User(
                id: id,
                firstname: firstname,
                lastname: lastname,
                email: email,
                mobile: mobile,
                registeredAt: DateTime.UtcNow,
                reminders: new List<Reminder>());
        }

        public User UpdateEmail(string email)
        {
            Email = email;

            return this;
        }

        public User CreateReminder(string email)
        {
            Email = email;

            return this;
        }

        public User UpdateChannelReminder(int reminderId, Channel channel)
        {
            var reminder = Reminders.FirstOrDefault(x => x.Id == reminderId);

            if (reminder is null)
                throw new Exception($"Reminder with id {reminderId} does not exist");

            var updatedRemider = reminder.UpdateChannel(channel);

            reminder = updatedRemider;

            return this;
        }

        public User UpdateMessageReminder(int reminderId, string message)
        {
            var reminder = Reminders.FirstOrDefault(x => x.Id == reminderId);

            if (reminder is null)
                throw new Exception($"Reminder with id {reminderId} does not exist");

            var updatedRemider = reminder.UpdateMessage(message);

            reminder = updatedRemider;

            return this;
        }

        public User UpdateMessageNotifyAt(int reminderId, DateTime notifyAt)
        {
            var reminder = Reminders.FirstOrDefault(x => x.Id == reminderId);

            if (reminder is null)
                throw new Exception($"Reminder with id {reminderId} does not exist");

            var updatedRemider = reminder.UpdateNotifyAt(notifyAt);

            reminder = updatedRemider;

            return this;
        }

        public User DeleteReminder(int reminderId)
        {
            var reminder = Reminders.FirstOrDefault(x => x.Id == reminderId);

            if (reminder is null)
                throw new Exception($"Reminder with id {reminderId} does not exist");

            Reminders.Remove(reminder);

            return this;
        }
    }
}
