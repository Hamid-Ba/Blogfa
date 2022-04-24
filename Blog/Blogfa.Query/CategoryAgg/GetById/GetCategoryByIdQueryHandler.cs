using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.CategoryAgg.GetById
{
    public class GetCategoryByIdQueryHandler : IBaseQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly BlogfaContext _context;

        public GetCategoryByIdQueryHandler(BlogfaContext context) => _context = context;

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == request.Id);
            return category.Map();
        }
    }
}