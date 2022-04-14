using System;
using Framework.Application;

namespace Blogfa.Application.CommentAgg.Confirm
{
    public record ConfirmCommentCommand(long Id) : IBaseCommand;
}