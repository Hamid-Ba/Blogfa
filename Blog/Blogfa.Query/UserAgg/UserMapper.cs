using Blogfa.Domain.UserAgg;
using Blogfa.Query.UserAgg.DTOs;

namespace Blogfa.Query.UserAgg
{
    public static class UserMapper
	{
		public static UserDto Map(this User user)
        {
			if (user is null) return null!;

			return new UserDto
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				IsActive = user.IsActive,
				Gender = user.Gender
			};
        }

		public static UserDto MapSingle(this User user)
        {
			if (user is null) return null!;

			return new UserDto
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				IsActive = user.IsActive,
				Gender = user.Gender,
				Avatar = user.Avatar,
				Password = user.Password,
				Roles = MapRoles(user.Roles)
			};
        }

		private static List<RolesDto> MapRoles(List<UserRole> roles)
        {
			if (roles is null) return null!;

			return roles.Select(r => new RolesDto
			{
				RoleId = r.RoleId
			}).ToList();
        }
	}
}