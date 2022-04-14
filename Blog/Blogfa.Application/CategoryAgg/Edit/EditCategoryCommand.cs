using System;
using Framework.Application;
using Framework.Domain.ValueObjects;

namespace Blogfa.Application.CategoryAgg.Edit
{
    public record EditCategoryCommand(long Id,string Title,string Slug,SeoData SeoData) : IBaseCommand;
}