using Blogfa.Domain.UserAgg.Repository;
using Blogfa.Domain.UserAgg.Services;

namespace Blogfa.Application.UserAgg
{
    public class UserDomainService : IUserDomainService
	{
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository) => _userRepository = userRepository;

        public bool IsPhoneNumberExist(string phoneNumber) => _userRepository.Exists(u => u.PhoneNumber == phoneNumber);
        
    }
}