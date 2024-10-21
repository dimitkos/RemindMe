using Shared;

namespace Domain.Aggregates
{
    public class User
    {
        public long Id { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public DateTime RegisteredAt { get; }
        public List<Reminder> Reminders { get; }

        public User(long id, string firstname, string lastname, string email, string mobile, DateTime registeredAt, List<Reminder> reminders)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Mobile = mobile;
            RegisteredAt = registeredAt;
            Reminders = reminders;
        }

        public static User Create(long id, string firstname, string lastname, string email, string mobile)
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
    }
}
