using Blogfa.Domain.UserAgg.Enums;
using Framework.Query;

namespace Blogfa.Query.UserAgg.DTOs
{
    public class UserDto : BaseDto
	{
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }

        public List<RolesDto> Roles { get; set; }
    }

    public class RolesDto
    {
        public long RoleId { get;  set; }
    }
}