using Blogfa.Application.UserAgg.Active;
using Blogfa.Application.UserAgg.ChangePassword;
using Blogfa.Application.UserAgg.Create;
using Blogfa.Application.UserAgg.DeActive;
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

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateUserCommand command) => CommandResult(await _userFacade.Create(command));

        [HttpPut("active")]
        public async Task<ApiResult> Active(ActiveUserCommand command) => CommandResult(await _userFacade.Active(command));

        [HttpPut("deActive")]
        public async Task<ApiResult> DeActive(DeActiveUserCommand command) => CommandResult(await _userFacade.DeActive(command));

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command) => CommandResult(await _userFacade.Edit(command));

        [HttpPut("changePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordUserCommand command) => CommandResult(await _userFacade.ChangePassword(command));
    }
}
