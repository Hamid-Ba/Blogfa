using Blogfa.Domain.ArticleAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.ChangeStatus
{
    internal class ChangeStatusArticleCommandHandler : IBaseCommandHandler<ChangeStatusArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public ChangeStatusArticleCommandHandler(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        public async Task<OperationResult> Handle(ChangeStatusArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAsTrackingAsyncBy(request.Id);
            if (article is null) return OperationResult.NotFound();

            article.ChangeStatus(request.Status, request.StatusDescription);
            await _articleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}