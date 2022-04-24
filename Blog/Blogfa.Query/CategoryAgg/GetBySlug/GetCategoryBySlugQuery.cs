using System;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.CategoryAgg.GetBySlug
{
    public record GetCategoryBySlugQuery(string Slug) : IBaseQuery<CategoryDto>;
}