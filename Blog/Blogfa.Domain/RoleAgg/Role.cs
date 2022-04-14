using Blogfa.Domain.RoleAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Blogfa.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        public string Title { get; private set; }
        public List<RolePermission> Permissions { get; private set; }

        private Role() { }

        public Role(string title, List<RolePermission> rolePermissions, IRoleDomainService roleService)
        {
            Guard(title, roleService);

            Title = title;
            AddPermissions(rolePermissions);
        }

        public void Edit(string title, List<RolePermission> rolePermissions, IRoleDomainService roleService)
        {
            Guard(title, roleService);

            Title = title;
            EditPermissions(rolePermissions);
        }

        public void AddPermissions(List<RolePermission> rolePermissions)
        {
            rolePermissions.ForEach(p => p.RoleId = Id);
            Permissions.AddRange(rolePermissions);
        }

        public void EditPermissions(List<RolePermission> rolePermissions)
        {
            Permissions.Clear();
            AddPermissions(rolePermissions);
        }

        public void Guard(string title, IRoleDomainService roleService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));

            if (roleService.IsTitleExist(title))
                if (Title != title)
                    throw new InvalidDomainDataException("This Title Is Already Exist");
        }
    }
}