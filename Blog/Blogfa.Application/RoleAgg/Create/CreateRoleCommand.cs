using Blogfa.Domain.RoleAgg.Enums;
using Framework.Application;

namespace Blogfa.Application.RoleAgg.Create
{
    public record CreateRoleCommand(string Title , List<Permission> Permissions) : IBaseCommand;
}