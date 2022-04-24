using System;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.CategoryAgg.GetById
{
    public record GetCategoryByIdQuery(long Id) : IBaseQuery<CategoryDto>;
}