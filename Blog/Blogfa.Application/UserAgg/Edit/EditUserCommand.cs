using Blogfa.Domain.UserAgg.Enums;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Blogfa.Application.UserAgg.Edit
{
    public record EditUserCommand(long Id,string FirstName, string LastName, string Avatar,IFormFile AvatarFile
		, Gender gender, List<long> Roles) : IBaseCommand;
}