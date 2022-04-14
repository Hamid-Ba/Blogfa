using System;
using Blogfa.Domain.CategoryAgg.Repository;
using Blogfa.Domain.CategoryAgg.Services;

namespace Blogfa.Application.CategoryAgg
{
	public class CategoryDomainService : ICategoryDomainService
	{
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDomainService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public bool IsSlugExist(string slug) => _categoryRepository.Exists(c => c.Slug == slug);
        
    }
}