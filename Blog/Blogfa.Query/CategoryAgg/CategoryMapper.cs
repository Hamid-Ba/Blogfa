using System;
using Blogfa.Domain.CategoryAgg;
using Blogfa.Query.CategoryAgg.DTOs;

namespace Blogfa.Query.CategoryAgg
{
	public static class CategoryMapper
	{
		public static CategoryDto Map(this Category category)
        {
			if (category is null) return null;

			return new CategoryDto
			{
				Id = category.Id,
				Title = category.Title,
				Slug = category.Slug,
				SeoData = category.SeoData,
				CreationDate = category.CreationDate,
			};
        }
	}
}