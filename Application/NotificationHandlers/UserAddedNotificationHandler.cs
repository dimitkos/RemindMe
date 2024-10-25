using Domain.DomainEvents;
using MediatR;
 
namespace Application.NotificationHandlers
{
    class UserAddedNotificationHandler : INotificationHandler<UserAdded>
    {
        public Task Handle(UserAdded notification, CancellationToken cancellationToken)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}
