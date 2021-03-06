using Framework.Domain;

namespace Blogfa.Domain.UserAgg
{
    public class UserRole : BaseEntity
	{
        public long UserId { get;internal set; }
        public long RoleId { get;private set; }

        public UserRole(long roleId) => RoleId = roleId;
        
    }
}