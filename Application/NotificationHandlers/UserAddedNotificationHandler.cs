using Application.Services;
using Domain.DomainEvents;
using MediatR;


namespace Application.NotificationHandlers
{
    class UserAddedNotificationHandler : INotificationHandler<UserAdded>
    {
        private readonly IEmailService _emailService;

        public UserAddedNotificationHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(UserAdded notification, CancellationToken cancellationToken)
            => await _emailService.Send(EmailType.Registration, notification.Email);
    }
}
