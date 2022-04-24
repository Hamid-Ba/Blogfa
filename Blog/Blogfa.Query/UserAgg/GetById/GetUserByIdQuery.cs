using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.UserAgg.GetById
{
    public record GetUserByIdQuery(long Id) : IBaseQuery<UserDto>;
}