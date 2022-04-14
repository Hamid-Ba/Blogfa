using Framework.Application;

namespace Blogfa.Application.UserAgg.Active
{
    public record ActiveUserCommand(long Id) : IBaseCommand;
}