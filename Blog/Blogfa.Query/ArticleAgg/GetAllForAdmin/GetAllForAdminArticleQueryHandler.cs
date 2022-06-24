using System;
using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.ArticleAgg.GetAllForAdmin
{
    public class GetAllForAdminArticleQueryHandler : IBaseQueryHandler<GetAllForAdminArticleQuery, List<ArticleDto>>
    {
        private readonly BlogfaContext _context;

        public GetAllForAdminArticleQueryHandler(BlogfaContext context) => _context = context;

        public async Task<List<ArticleDto>> Handle(GetAllForAdminArticleQuery request, CancellationToken cancellationToken)
        {
            var articles = await _context.Article.ToListAsync();
            return articles.Select(m => m.Map(_context)).ToList();
        }
    }
}