using Blogfa.Application.UserAgg.ChangePassword;
using Blogfa.Application.UserAgg.Edit;
using Blogfa.Presentation.Facade.UserAgg;
using Blogfa.Query.UserAgg.DTOs;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class UserApiController : BaseApiController
    {
        private readonly IUserFacade _userFacade;

        public UserApiController(IUserFacade userFacade) => _userFacade = userFacade;

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetAll([FromQuery] UserFilterParam filter) => QueryResult(await _userFacade.GetAll(filter));

        [HttpGet("{id}")]
        public async Task<ApiResult<UserDto>> GetBy(long id) => QueryResult(await _userFacade.GetBy(id));

        [HttpGet("{phoneNumber}")]
        public async Task<ApiResult<UserDto>> GetBy(string phoneNumber) => QueryResult(await _userFacade.GetBy(phoneNumber));

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command) => CommandResult(await _userFacade.Edit(command));

        [HttpPut("changePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordUserCommand command) => CommandResult(await _userFacade.ChangePassword(command));
    }
}
