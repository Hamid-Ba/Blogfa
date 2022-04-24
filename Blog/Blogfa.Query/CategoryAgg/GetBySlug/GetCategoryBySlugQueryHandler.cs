using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.CategoryAgg.GetBySlug
{
    public class GetCategoryBySlugQueryHandler : IBaseQueryHandler<GetCategoryBySlugQuery, CategoryDto>
    {
        private readonly BlogfaContext _context;

        public GetCategoryBySlugQueryHandler(BlogfaContext context) => _context = context;

        public async Task<CategoryDto> Handle(GetCategoryBySlugQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Slug == request.Slug);
            return category.Map();
        }
    }
}