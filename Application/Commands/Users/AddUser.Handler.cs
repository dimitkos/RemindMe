using MediatR;

namespace Application.Commands.Users
{
    class AddUserHandler : IRequestHandler<AddUser, Unit>
    {
        public Task<Unit> Handle(AddUser request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
