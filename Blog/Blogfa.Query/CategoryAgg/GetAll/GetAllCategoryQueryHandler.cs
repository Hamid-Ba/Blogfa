using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.CategoryAgg.GetAll
{
    public class GetAllCategoryQueryHandler : IBaseQueryHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly BlogfaContext _context;

        public GetAllCategoryQueryHandler(BlogfaContext context) => _context = context;

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Category.ToListAsync();
            return categories.Select(c => c.Map()).ToList();
        }
    }
}