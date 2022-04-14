using System;
using Framework.Application;
using Framework.Domain.ValueObjects;

namespace Blogfa.Application.CategoryAgg.Create
{
    public record CreateCategoryCommand(string Title, string Slug, SeoData SeoData) : IBaseCommand;
}