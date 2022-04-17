using Framework.Query;

namespace Blogfa.Query.ArticleAgg.DTOs
{
    public class ArticleLikeDto : BaseDto
    {
        public long ArtileId { get; set; }
        public long UserId { get; set; }
    }   
}