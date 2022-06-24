using System;
using Blogfa.Query.ArticleAgg.DTOs;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.ArticleAgg.GetAllForAdmin
{
	public record GetAllForAdminArticleQuery : IBaseQuery<List<ArticleDto>>;
}