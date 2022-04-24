using Blogfa.Query.RoleAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.RoleAgg.GetAll
{
    public record GetAllRoleQuery : IBaseQuery<List<RoleDto>>;
}