using Blogfa.Query.RoleAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.RoleAgg.GetBy
{
    public record GetRoleByIdQuery(long Id) : IBaseQuery<RoleDto>;
}