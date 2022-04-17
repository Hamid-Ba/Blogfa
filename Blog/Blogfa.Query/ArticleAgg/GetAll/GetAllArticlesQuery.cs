using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.ArticleAgg.GetAll
{
    public class GetAllArticlesQuery : QueryFilter<ArticleFilterResult, ArticleFilterParam>
    {
        public GetAllArticlesQuery(ArticleFilterParam filterParams) : base(filterParams)
        {
        }
    }
}