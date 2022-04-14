using Blogfa.Domain.UserAgg.Repository;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;

namespace Blogfa.Application.UserAgg.ChangePassword
{
    internal class ChangePasswordUserCommandHandler : IBaseCommandHandler<ChangePasswordUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> Handle(ChangePasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.Id);
            if (user is null) return OperationResult.NotFound();

            var password = _passwordHasher.Hash(request.Password);

            user.ChangePassword(password);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}