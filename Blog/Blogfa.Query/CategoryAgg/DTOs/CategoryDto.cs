using System;
using Framework.Domain.ValueObjects;
using Framework.Query;

namespace Blogfa.Query.CategoryAgg.DTOs
{
	public class CategoryDto : BaseDto
	{
		public string Title { get;  set; }
		public string Slug { get; set; }
		public SeoData SeoData { get; set; }
	}
}