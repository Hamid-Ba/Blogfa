﻿using Blogfa.Domain.UserAgg.Enums;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace Blogfa.Application.UserAgg.Create
{
    public record CreateUserCommand(string FirstName, string LastName, IFormFile Avatar, string Password, string PhoneNumber,
			bool IsActive, Gender Gender, List<long> Roles) : IBaseCommand;
}