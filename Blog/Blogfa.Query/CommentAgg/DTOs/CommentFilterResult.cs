using Framework.Query.Filter;

namespace Blogfa.Query.CommentAgg.DTOs
{
    public class CommentFilterParam : BaseFilterParam
    {
        public string? UserFullName { get; set; }
        public string? UserPhone { get; set; }
        public string? ArticleTitle { get; set; }
    }

    public class CommentFilterResult : BaseFilter<CommentDto , CommentFilterParam> { }
}