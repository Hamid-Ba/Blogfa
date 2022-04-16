using Blogfa.Domain.UserAgg;
using Blogfa.Domain.UserAgg.Repository;
using Framework.Infrastructure;

namespace Blogfa.Infrastructure.EfCore.UserAgg
{
    public class UserRepository : Repository<User> , IUserRepository
	{
		private readonly BlogfaContext _context;

		public UserRepository(BlogfaContext context) : base(context) => _context = context;
	}
}