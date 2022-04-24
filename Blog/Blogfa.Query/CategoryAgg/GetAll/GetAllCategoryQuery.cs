using System;
using Blogfa.Query.CategoryAgg.DTOs;
using Framework.Query;

namespace Blogfa.Query.CategoryAgg.GetAll
{
    public record GetAllCategoryQuery : IBaseQuery<List<CategoryDto>>;
}