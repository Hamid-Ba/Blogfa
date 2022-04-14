using Blogfa.Domain.ArticleAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.DisLike
{
    internal class DisLikeArticleCommandHandler : IBaseCommandHandler<DisLikeArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public DisLikeArticleCommandHandler(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        public async Task<OperationResult> Handle(DisLikeArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAsTrackingAsyncBy(request.Id);
            if (article is null) return OperationResult.NotFound();

            article.DisLike(request.UserId);
            await _articleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}