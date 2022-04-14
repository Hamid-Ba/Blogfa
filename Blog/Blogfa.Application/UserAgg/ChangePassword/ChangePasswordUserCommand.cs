using Framework.Application;

namespace Blogfa.Application.UserAgg.ChangePassword
{
    public record ChangePasswordUserCommand(long Id,string Password) : IBaseCommand;
}