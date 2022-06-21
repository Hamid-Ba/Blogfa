using Blogfa.Application.UserAgg.Register;
using Blogfa.Presentation.Facade.UserAgg;
using Blogfa.Query.UserAgg.DTOs;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Presentation.Api;
using Framework.Presentation.Api.JwtTools;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Api.DTOs.LoginDtos;

namespace ServiceHost.Api.Controllers
{
    public class AuthApiController : BaseApiController
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IUserFacade _userFacade;
        private readonly IPasswordHasher _passwordHasher;

        public AuthApiController(IJwtHelper jwtHelper, IUserFacade userFacade, IPasswordHasher passwordHasher)
        {
            _jwtHelper = jwtHelper;
            _userFacade = userFacade;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterUserCommand command) => CommandResult(await _userFacade.Register(command));

        [HttpPost("login")]
        public async Task<ApiResult> Login(LoginDto command)
        {
            var user = await _userFacade.GetBy(command.PhoneNumber);

            if(user is null) return CommandResult(OperationResult.NotFound("کاربری با این مشخصات یافت نشد"));

            if (!_passwordHasher.Check(user.Password, command.Password).Verified)
                return CommandResult(OperationResult.Error("رمزعبور درست نمی باشد"));

            if (user.IsActive == false)
                return CommandResult(OperationResult.Error("حساب کاربری شما غیرفعال است"));

            var result =  GetToken(user);

            return result;
        }

        private  ApiResult<LoginResultDto> GetToken(UserDto userDto)
        {
            var jwtDto = new JwtDto(userDto.Id, $"{userDto.FirstName} {userDto.LastName}", userDto.PhoneNumber);
            var token = _jwtHelper.SignIn(jwtDto);

            return new ApiResult<LoginResultDto>
            {
                Data = new(token),
                IsSuccess = true,
                MetaData = new()
                {
                    Message = "ورود با موفقیت انجام شد",
                    Status = ApiStatusCode.Success
                }
            };
        }
    }
}