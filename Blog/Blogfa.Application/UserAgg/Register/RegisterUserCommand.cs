using Framework.Application;

namespace Blogfa.Application.UserAgg.Register
{
    public record RegisterUserCommand(string FirstName, string LastName, string PhoneNumber, string Password) : IBaseCommand;
}