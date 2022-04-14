using Blogfa.Domain.RoleAgg;
using Blogfa.Domain.RoleAgg.Repository;
using Blogfa.Domain.RoleAgg.Services;
using Framework.Application;

namespace Blogfa.Application.RoleAgg.Create
{
    internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleDomainService _roleDomainService;

        public CreateRoleCommandHandler(IRoleRepository roleRepository, IRoleDomainService roleDomainService)
        {
            _roleRepository = roleRepository;
            _roleDomainService = roleDomainService;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var rolePermissions = new List<RolePermission>();
            request.Permissions.ForEach(p => rolePermissions.Add(new RolePermission(p)));

            var role = new Role(request.Title, rolePermissions, _roleDomainService);
            await _roleRepository.AddEntityAsync(role);

            await _roleRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}