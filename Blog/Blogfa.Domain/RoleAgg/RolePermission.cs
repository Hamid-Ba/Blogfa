using Blogfa.Domain.RoleAgg.Enums;
using Framework.Domain;

namespace Blogfa.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
	{
        public long RoleId { get;internal set; }
        public Permission Permission { get; set; }

        public RolePermission(Permission permission) => Permission = permission;
	}
}