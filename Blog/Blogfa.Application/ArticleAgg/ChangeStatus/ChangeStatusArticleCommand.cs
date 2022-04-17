using System;
using Blogfa.Domain.ArticleAgg.Enums;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.ChangeStatus
{
    public record ChangeStatusArticleCommand(long Id,ArticleStatus Status,string StatusDescription) : IBaseCommand;
}