using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.UserAgg.GetByPhone
{
    public record GetUserByPhoneQuery(string PhoneNumber) : IBaseQuery<UserDto>;
}