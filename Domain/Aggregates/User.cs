namespace Domain.Aggregates
{
    public class User : Entity<long>
    {
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public DateTime RegisteredAt { get; }

        public User(long id, string firstname, string lastname, string email, string mobile, DateTime registeredAt) : base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Mobile = mobile;
            RegisteredAt = registeredAt;
        }

        private User() : base(default)
        {
            Firstname = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Mobile = string.Empty;
        }

        public static User Create(long id, string firstname, string lastname, string email, string mobile)
        {
            return new User(
                id: id,
                firstname: firstname,
                lastname: lastname,
                email: email,
                mobile: mobile,
                registeredAt: DateTime.UtcNow);
        }

        public User UpdateEmail(string email)
        {
            Email = email;

            return this;
        }
    }
}
