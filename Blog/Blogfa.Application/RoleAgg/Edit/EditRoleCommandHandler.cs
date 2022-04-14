using Blogfa.Domain.RoleAgg;
using Blogfa.Domain.RoleAgg.Repository;
using Blogfa.Domain.RoleAgg.Services;
using Framework.Application;

namespace Blogfa.Application.RoleAgg.Edit
{
    internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleDomainService _roleDomainService;

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetAsTrackingAsyncBy(request.Id);
            if (role is null) return OperationResult.NotFound();

            var rolePermissions = new List<RolePermission>();
            request.Permissions.ForEach(p => rolePermissions.Add(new RolePermission(p)));

            role.Edit(request.Title, rolePermissions, _roleDomainService);
            await _roleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}