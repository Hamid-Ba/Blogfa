using System;
namespace Blogfa.Domain.ArticleAgg.Services
{
	public interface IArticleDomainService
	{
		bool IsSlugExist(string slug);
	}
}

