using Blogfa.Domain.ArticleAgg;
using Blogfa.Domain.ArticleAgg.Repository;
using Blogfa.Domain.ArticleAgg.Services;
using Framework.Application;
using Framework.Application.Utils;

namespace Blogfa.Application.ArticleAgg.Create
{
    internal class CreateArticleCommandHandler : IBaseCommandHandler<CreateArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleDomainService _articleDomainService;

        public CreateArticleCommandHandler(IArticleRepository articleRepository, IArticleDomainService articleDomainService)
        {
            _articleRepository = articleRepository;
            _articleDomainService = articleDomainService;
        }

        public async Task<OperationResult> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var imageName = Uploader.ImageUploader(request.ImageFile, DirectoryImages.Articles, null!);

            var article = new Article(request.Title, request.UserId, request.CategoryId, request.Slug, imageName, request.SeoImage, request.Description,
                request.SeoData, _articleDomainService);

            await _articleRepository.AddEntityAsync(article);
            await _articleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}