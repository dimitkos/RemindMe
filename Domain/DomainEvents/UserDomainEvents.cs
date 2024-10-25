namespace Domain.DomainEvents
{
    public class UserAdded : DomainEvent
    {
        public long Id { get; }
        public string FirstName { get; }
        public string Email { get; }

        public UserAdded(long id, string firstName, string email)
        {
            Id = id;
            FirstName = firstName;
            Email = email;
        }
    }
}
