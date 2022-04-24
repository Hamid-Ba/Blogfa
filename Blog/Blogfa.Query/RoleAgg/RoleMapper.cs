using Blogfa.Domain.RoleAgg;
using Blogfa.Query.RoleAgg.DTOs;

namespace Blogfa.Query.RoleAgg
{
    public static class RoleMapper
	{
		public static RoleDto Map(this Role role)
        {
			if (role is null) return null!;

			return new RoleDto
			{
				Id = role.Id,
				Title = role.Title,
				CreationDate = role.CreationDate,
				Permissions = MapPermissions(role.Permissions)
			};
        }

		public static List<PermissionDto> MapPermissions(List<RolePermission> permissions)
		{
			if (permissions is null) return null!;

			return permissions.Select(p => new PermissionDto
			{
				Permission = p.Permission
			}).ToList();
		}
	}
}