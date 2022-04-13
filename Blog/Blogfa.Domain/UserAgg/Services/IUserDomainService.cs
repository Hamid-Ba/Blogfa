namespace Blogfa.Domain.UserAgg.Services
{
    public interface IUserDomainService
	{
		bool IsPhoneNumberExist(string phoneNumber);
	}
}