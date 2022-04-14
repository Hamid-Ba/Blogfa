using System;
namespace Blogfa.Domain.CategoryAgg.Services
{
	public interface ICategoryDomainService
	{
		bool IsSlugExist(string slug);
	}
}