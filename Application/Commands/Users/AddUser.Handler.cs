using Application.Services.Infrastructure.Users;
using Domain.Aggregates;
using Domain.DomainEvents;
using IdGen;
using MediatR;

namespace Application.Commands.Users
{
    class AddUserHandler : IRequestHandler<AddUser, Unit>
    {
        private readonly IUserCommandRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IdGenerator _idGenerator;

        public AddUserHandler(IUserCommandRepository userRepository, IMediator mediator, IdGenerator idGenerator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
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

            await _mediator.Publish(new UserAdded(user.Id, user.Firstname, user.Email));

            return Unit.Value;
        }
    }
}
