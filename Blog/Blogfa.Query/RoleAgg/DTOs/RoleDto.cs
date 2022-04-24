using Blogfa.Domain.RoleAgg.Enums;
using Framework.Query;

namespace Blogfa.Query.RoleAgg.DTOs
{
    public class RoleDto : BaseDto
	{
		public string Title { get;  set; }
		public List<PermissionDto> Permissions { get;  set; }
	}

	public class PermissionDto
    {
		public Permission Permission { get; set; }
	}
}