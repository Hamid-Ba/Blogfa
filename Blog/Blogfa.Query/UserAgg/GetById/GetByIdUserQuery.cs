using Blogfa.Query.UserAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.UserAgg.GetById
{
    public record GetByIdUserQuery(long Id) : IBaseQuery<UserDto>;
}