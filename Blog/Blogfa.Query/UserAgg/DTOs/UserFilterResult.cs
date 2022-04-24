using Framework.Query.Filter;

namespace Blogfa.Query.UserAgg.DTOs
{
    public class UserFilterParam : BaseFilterParam
    {
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class UserFilterResult : BaseFilter<UserDto, UserFilterParam> { }
}