using System;
using Blogfa.Query.CommentAgg.DTOs;
using Framework.Query;
using Framework.Query.Filter;

namespace Blogfa.Query.CommentAgg.GetAll
{
    public class GetAllCommentQuery : QueryFilter<CommentFilterResult, CommentFilterParam>
    {
        public GetAllCommentQuery(CommentFilterParam filterParams) : base(filterParams)
        {
        }
    }
}