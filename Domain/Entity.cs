using System.Security.Cryptography.X509Certificates;

namespace Domain
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; }
    }

    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; }

        public Entity(TKey id)
        {
            Id = id;
        }
    }
}
