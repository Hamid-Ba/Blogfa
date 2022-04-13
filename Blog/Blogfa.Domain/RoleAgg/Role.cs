using Blogfa.Domain.RoleAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Blogfa.Domain.RoleAgg
{
    public class Role : AggregateRoot
	{
        public string Title { get;private set; }
        public List<RolePermission> Permissions { get;private set; }

        public Role(string title,IRoleDomainService roleService)
		{
			Guard(title,roleService);

			Title = title;
			Permissions = new();
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

		public void Guard(string title,IRoleDomainService roleService)
        {
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));

			if (roleService.IsTitleExist(title))
				throw new InvalidDomainDataException("This Title Is Already Exist");
        }
	}
}