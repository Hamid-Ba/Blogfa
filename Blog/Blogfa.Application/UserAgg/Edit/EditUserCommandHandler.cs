using Blogfa.Domain.UserAgg;
using Blogfa.Domain.UserAgg.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Blogfa.Application.UserAgg.Edit
{
    internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.Id);
            if (user is null) return OperationResult.NotFound();

            //Config Role
            var userRoles = new List<UserRole>();
            request.Roles.ForEach(r => userRoles.Add(new UserRole(r)));

            //Config Avatar
            var avatar = Uploader.ImageUploader(request.AvatarFile, DirectoryImages.Avatars, request.Avatar);

            //Edit User
            user.Edit(request.FirstName, request.LastName, avatar, request.gender, userRoles);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}