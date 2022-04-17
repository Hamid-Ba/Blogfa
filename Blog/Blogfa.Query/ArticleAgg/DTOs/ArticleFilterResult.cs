using Framework.Query.Filter;

namespace Blogfa.Query.ArticleAgg.DTOs
{

    public class ArticleFilterParam : BaseFilterParam
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
    }

    public class ArticleFilterResult : BaseFilter<ArticleDto, ArticleFilterParam> { }
    
}