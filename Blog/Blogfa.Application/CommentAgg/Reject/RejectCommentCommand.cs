using System;
using Framework.Application;

namespace Blogfa.Application.CommentAgg.Reject
{
    public record RejectCommentCommand(long Id) : IBaseCommand;
}