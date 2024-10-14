using MediatR;

namespace Application.Commands.Users
{
    class UpdateEmailHandler : IRequestHandler<UpdateEmail, Unit>
    {
        public Task<Unit> Handle(UpdateEmail request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
