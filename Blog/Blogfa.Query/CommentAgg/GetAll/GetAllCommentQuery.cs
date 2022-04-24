using Blogfa.Query.CommentAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.CommentAgg.GetAll
{
    public class GetAllCommentQuery : QueryFilter<CommentFilterResult, CommentFilterParam>
    {
        public GetAllCommentQuery(CommentFilterParam filterParams) : base(filterParams)
        {
        }
    }
}