using Blogfa.Domain.RoleAgg.Repository;
using Blogfa.Domain.RoleAgg.Services;

namespace Blogfa.Application.RoleAgg
{
    public class RoleDomainService : IRoleDomainService
	{
        private readonly IRoleRepository _roleRepository;

        public RoleDomainService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public bool IsTitleExist(string title) => _roleRepository.Exists(r => r.Title == title);
        
    }
}