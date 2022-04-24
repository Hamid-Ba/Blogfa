using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.ArticleAgg.GetBySlug
{
    public class GetArticleBySlugQueryHandler : IBaseQueryHandler<GetArticleBySlugQuery, ArticleDto>
    {
        private readonly BlogfaContext _context;

        public GetArticleBySlugQueryHandler(BlogfaContext context) => _context = context;

        public async Task<ArticleDto> Handle(GetArticleBySlugQuery request, CancellationToken cancellationToken)
        {
            var article = await _context.Article.FirstOrDefaultAsync(a => a.Slug == request.Slug);
            if (article is null) return new();

            return article.Map(_context);
        }
    }
}