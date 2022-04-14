using System;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.Like
{
    public record LikeArticleCommand(long Id,long UserId) : IBaseCommand;
}