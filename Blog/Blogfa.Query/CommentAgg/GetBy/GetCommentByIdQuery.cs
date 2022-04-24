using Blogfa.Query.CommentAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.CommentAgg.GetBy
{
    public record GetCommentByIdQuery(long Id) : IBaseQuery<CommentDto>;
}