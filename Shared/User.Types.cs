namespace Shared
{
    public class AddUserPayload
    {
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public string Mobile { get; }

        public AddUserPayload(string firstname, string lastname, string email, string mobile)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Mobile = mobile;
        }
    }

    public class UpdateEmailPayload
    {
        public int UserId { get; }
        public string Email { get; }

        public UpdateEmailPayload(int userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}
