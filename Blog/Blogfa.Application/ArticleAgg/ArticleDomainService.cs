using System;
using Blogfa.Domain.ArticleAgg.Repository;
using Blogfa.Domain.ArticleAgg.Services;

namespace Blogfa.Application.ArticleAgg
{
	public class ArticleDomainService : IArticleDomainService
	{
        private readonly IArticleRepository _articleRepository;

        public ArticleDomainService(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        public bool IsSlugExist(string slug) => _articleRepository.Exists(a => a.Slug == slug);
        
    }
}