using Domain.Aggregates;
using IdGen;
using MediatR;

namespace Application.Commands.Users
{
    class AddUserHandler : IRequestHandler<AddUser, Unit>
    {
        private readonly IdGenerator _idGenerator;

        public AddUserHandler(IdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public Task<Unit> Handle(AddUser request, CancellationToken cancellationToken)
        {
            var user = User.Create(
                id: _idGenerator.CreateId(),
                firstname: request.Payload.Firstname,
                lastname: request.Payload.Lastname,
                email: request.Payload.Email,
                mobile: request.Payload.Mobile);

            throw new NotImplementedException();
        }
    }
}
