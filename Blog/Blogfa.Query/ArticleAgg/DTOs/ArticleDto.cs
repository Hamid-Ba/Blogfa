using Framework.Domain.ValueObjects;
using Framework.Query;
using Framework.Query.Filter;

namespace Blogfa.Query.ArticleAgg.DTOs
{
    public class ArticleDto : BaseDto
	{
        public string Title { get;  set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
        public SeoImage SeoImage { get;set; }
        public string Description { get; set; }
        public SeoData SeoData { get; set; }
        public int ViewerCount { get; set; }

        public ArticleCategoryDto Category { get; set; }
        public List<ArticleLikeDto> Likes { get; set; }
    }

   
    
}