using Blogfa.Domain.RoleAgg;
using Blogfa.Domain.RoleAgg.Repository;
using Framework.Infrastructure;

namespace Blogfa.Infrastructure.EfCore.RoleAgg
{
    public class RoleRepository : Repository<Role>, IRoleRepository
	{
		private readonly BlogfaContext _context;

		public RoleRepository(BlogfaContext context) : base(context) => _context = context;
	}
}