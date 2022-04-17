using System;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.ArticleAgg.GetBySlug
{
    public record GetArticleBySlugQuery(string Slug) : IBaseQuery<ArticleDto>;
}