using System;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.AddView
{
    public record AddViewArticleCommand(long Id) : IBaseCommand;
}