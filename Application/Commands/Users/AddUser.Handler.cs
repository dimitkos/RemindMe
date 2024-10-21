using Application.Services.Infrastructure.Users;
using Domain.Aggregates;
using IdGen;
using MediatR;

namespace Application.Commands.Users
{
    class AddUserHandler : IRequestHandler<AddUser, Unit>
    {
        private readonly IUserCommandRepository _userRepository;
        private readonly IdGenerator _idGenerator;

        public AddUserHandler(IUserCommandRepository userRepository, IdGenerator idGenerator)
        {
            _userRepository = userRepository;
            _idGenerator = idGenerator;
        }

        public async Task<Unit> Handle(AddUser request, CancellationToken cancellationToken)
        {
            var user = User.Create(
                id: _idGenerator.CreateId(),
                firstname: request.Payload.Firstname,
                lastname: request.Payload.Lastname,
                email: request.Payload.Email,
                mobile: request.Payload.Mobile);

            await _userRepository.Create(user);

            return Unit.Value;
        }
    }
}
