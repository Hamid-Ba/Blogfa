namespace ServiceHost.Api.DTOs.LoginDtos
{
    public class LoginResultDto
	{
		public string Token { get; private set; }

		public LoginResultDto(string token) => Token = token;
	}
}