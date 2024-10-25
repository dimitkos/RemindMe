using Domain.DomainEvents;
using MediatR;
 
namespace Application.NotificationHandlers
{
    class UserAddedNotificationHandler : INotificationHandler<UserAdded>
    {
        public Task Handle(UserAdded notification, CancellationToken cancellationToken)
        {
            //implement later to send email
            throw new NotImplementedException();
        }
    }
}
