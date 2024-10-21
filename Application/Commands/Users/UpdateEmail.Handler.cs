using Application.Services.Infrastructure;
using Application.Services.Infrastructure.Users;
using Domain.Aggregates;
using MediatR;

namespace Application.Commands.Users
{
    class UpdateEmailHandler : IRequestHandler<UpdateEmail, Unit>
    {
        private readonly IUserCommandRepository _userRepository;
        private readonly IDomainRetrievalRepository<long, User> _userRetrieval;

        public UpdateEmailHandler(IUserCommandRepository userRepository, IDomainRetrievalRepository<long, User> userRetrieval)
        {
            _userRepository = userRepository;
            _userRetrieval = userRetrieval;
        }

        public async Task<Unit> Handle(UpdateEmail request, CancellationToken cancellationToken)
        {
            var user = await _userRetrieval.TryGet(request.Payload.UserId);

            if (user is null)
                throw new Exception($"User with id: {request.Payload.UserId} not found");

            await _userRepository.UpdateEmail(user);

            return Unit.Value;
        }
    }
}
