using Blogfa.Domain.CategoryAgg;
using Blogfa.Domain.CategoryAgg.Repository;
using Blogfa.Domain.CategoryAgg.Services;
using Framework.Application;

namespace Blogfa.Application.CategoryAgg.Create
{
    internal class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDomainService _categoryDomainService;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
        {
            _categoryRepository = categoryRepository;
            _categoryDomainService = categoryDomainService;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Title, request.Slug, request.SeoData, _categoryDomainService);

            await _categoryRepository.AddEntityAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}