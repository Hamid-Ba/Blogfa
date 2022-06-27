using Blogfa.Domain.UserAgg;
using Blogfa.Domain.UserAgg.Repository;
using Blogfa.Domain.UserAgg.Services;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Application.Utils;

namespace Blogfa.Application.UserAgg.Create
{
    internal class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserDomainService _userDomainService;

        public CreateUserCommandHandler(IUserRepository userRepository,IPasswordHasher passwordHasher, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Config Avatar            
            var imageName = Uploader.ImageUploader(request.Avatar, DirectoryImages.Avatars, null!);

            //Config Password
            var password = _passwordHasher.Hash(request.Password);

            //Create User
            var user = new User(request.FirstName, request.LastName, imageName, password, request.PhoneNumber,
                true, request.Gender, _userDomainService);

            await _userRepository.AddEntityAsync(user);

            //Add Roles
            List<UserRole> Roles = new List<UserRole>();

            request.Roles.ForEach(r =>
            {
                var role = new UserRole(r);
                Roles.Add(role);
            });

            user.AddRoles(Roles);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}