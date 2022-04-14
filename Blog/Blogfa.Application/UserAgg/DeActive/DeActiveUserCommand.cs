using Framework.Application;

namespace Blogfa.Application.UserAgg.DeActive
{
    public record DeActiveUserCommand(long Id) : IBaseCommand;
}