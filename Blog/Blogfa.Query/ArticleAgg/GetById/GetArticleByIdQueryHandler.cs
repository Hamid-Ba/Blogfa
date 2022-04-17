using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.ArticleAgg.GetById
{
    internal class GetArticleByIdQueryHandler : IBaseQueryHandler<GetArticleByIdQuery, ArticleDto>
    {
        private readonly BlogfaContext _context;

        public GetArticleByIdQueryHandler(BlogfaContext context) => _context = context;

        public async Task<ArticleDto> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _context.Article.FirstOrDefaultAsync(a => a.Id == request.Id);
            if (article is null) return new ArticleDto();

            return article.Map(_context);
        }
    }
}