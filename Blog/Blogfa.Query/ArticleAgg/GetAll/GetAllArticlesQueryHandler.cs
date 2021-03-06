using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.ArticleAgg.GetAll
{
    public class GetAllArticlesQueryHandler : IBaseQueryHandler<GetAllArticlesQuery, ArticleFilterResult>
    {
        private readonly BlogfaContext _context;

        public GetAllArticlesQueryHandler(BlogfaContext context) => _context = context;

        public async Task<ArticleFilterResult> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var user =await _context.User.Select(u => new { Id = u.Id, FullName = $"{u.FirstName} {u.LastName}" })
                .ToListAsync();

            var mapCategory = await _context.Category.Select(c => new ArticleCategoryDto
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug
            }).ToListAsync();

            var @params = request.FilterParams;
            var articles = _context.Article.AsQueryable();

            #region Apply Parameters

            if (!string.IsNullOrWhiteSpace(@params.Title))
                articles = articles.Where(a => a.Title.Contains(@params.Title));

            if (@params.UserId != null || @params.UserId > 0)
                articles = articles.Where(a => a.UserId == @params.UserId);

            if (!string.IsNullOrWhiteSpace(@params.Slug))
                articles = articles.Where(a => a.Slug == @params.Slug);

            if (@params.CategoryId != null || @params.CategoryId > 0)
                articles = articles.Where(a => a.CategoryId == @params.CategoryId);

            if (!string.IsNullOrWhiteSpace(@params.CategorySlug))
            {
                var category = await _context.Category.FirstOrDefaultAsync(c => c.Slug == @params.CategorySlug);
                articles = articles.Where(a => a.CategoryId == category.Id);
            }

            #endregion

            var skip = (@params.PageId - 1) * @params.Take;

            var result = new ArticleFilterResult()
            {
                FilterParams = @params,
                Data = await articles.Skip(skip).Take(@params.Take).Select(a => a.MapResult()).ToListAsync()
            };

            result.Data.ForEach(d => d.UserFullName = user.Find(u => u.Id == d.UserId)?.FullName!);
            result.Data.ForEach(d => d.Category = mapCategory.Find(u => u.Id == d.Category.Id)!);

            result.GeneratePaging(articles, @params.Take, @params.PageId);

            return result;
        }
    }
}