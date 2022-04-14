using System;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.DisLike
{
    public record DisLikeArticleCommand(long Id,long UserId) : IBaseCommand;
}