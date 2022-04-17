using Framework.Query;

namespace Blogfa.Query.ArticleAgg.DTOs
{
    public class ArticleCategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
    
}