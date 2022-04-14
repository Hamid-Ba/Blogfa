using System;
using Framework.Application;

namespace Blogfa.Application.CommentAgg.Create
{
    public record CreateCommentCommand(long UserId, long ArticleId, string Content) : IBaseCommand;
}