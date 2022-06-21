using Blogfa.Domain.UserAgg;
using Blogfa.Domain.UserAgg.Repository;
using Blogfa.Domain.UserAgg.Services;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;

namespace Blogfa.Application.UserAgg.Register
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserDomainService _userDomainService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //Config Password
            var password = _passwordHasher.Hash(request.Password);

            //Create User
            var user = User.Register(request.FirstName, request.LastName, password, request.PhoneNumber, _userDomainService);

            await _userRepository.AddEntityAsync(user);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}