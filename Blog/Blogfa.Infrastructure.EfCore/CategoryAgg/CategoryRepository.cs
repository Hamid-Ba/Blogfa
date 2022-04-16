using Blogfa.Domain.CategoryAgg;
using Blogfa.Domain.CategoryAgg.Repository;
using Framework.Infrastructure;

namespace Blogfa.Infrastructure.EfCore.CategoryAgg
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly BlogfaContext _context;

		public CategoryRepository(BlogfaContext context) : base(context) => _context = context;
	}
}