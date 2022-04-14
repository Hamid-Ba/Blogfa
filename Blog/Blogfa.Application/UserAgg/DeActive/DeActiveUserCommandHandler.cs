using Blogfa.Domain.UserAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.UserAgg.DeActive
{
    internal class DeActiveUserCommandHandler : IBaseCommandHandler<DeActiveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeActiveUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(DeActiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.Id);
            if (user is null) return OperationResult.NotFound();

            user.DeActive();
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}