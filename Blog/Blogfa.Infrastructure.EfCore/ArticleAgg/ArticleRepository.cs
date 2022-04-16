using System;
using Blogfa.Domain.ArticleAgg;
using Blogfa.Domain.ArticleAgg.Repository;
using Framework.Infrastructure;

namespace Blogfa.Infrastructure.EfCore.ArticleAgg
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
	{
		private readonly BlogfaContext _context;

        public ArticleRepository(BlogfaContext context) : base(context) => _context = context;
    }
}