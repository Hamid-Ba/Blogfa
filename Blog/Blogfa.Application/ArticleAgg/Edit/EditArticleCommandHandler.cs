using Blogfa.Domain.ArticleAgg.Repository;
using Blogfa.Domain.ArticleAgg.Services;
using Framework.Application;
using Framework.Application.Utils;

namespace Blogfa.Application.ArticleAgg.Edit
{
    internal class EditArticleCommandHandler : IBaseCommandHandler<EditArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleDomainService _articleDomainService;

        public EditArticleCommandHandler(IArticleRepository articleRepository, IArticleDomainService articleDomainService)
        {
            _articleRepository = articleRepository;
            _articleDomainService = articleDomainService;
        }

        public async Task<OperationResult> Handle(EditArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAsTrackingAsyncBy(request.Id);
            if (article is null) return OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.ImageFile, DirectoryImages.Articles, request.ImageName);
            article.Edit(request.Title, request.CategoryId, request.Slug, imageName, request.SeoImage, request.Description
                , request.SeoData,request.PublishDate, _articleDomainService);

            await _articleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}