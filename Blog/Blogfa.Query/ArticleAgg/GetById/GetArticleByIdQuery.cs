using System;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.ArticleAgg.GetById
{
    public record GetArticleByIdQuery(long Id) : IBaseQuery<ArticleDto>;
}