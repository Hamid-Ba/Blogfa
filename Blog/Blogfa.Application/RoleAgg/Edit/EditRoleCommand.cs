using Blogfa.Domain.RoleAgg.Enums;
using Framework.Application;

namespace Blogfa.Application.RoleAgg.Edit
{
    public record EditRoleCommand(long Id,string Title,List<Permission> Permissions) : IBaseCommand;
}