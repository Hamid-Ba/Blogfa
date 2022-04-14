using Blogfa.Domain.ArticleAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.Like
{
    internal class LikeArticleCommandHandler : IBaseCommandHandler<LikeArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public LikeArticleCommandHandler(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        public async Task<OperationResult> Handle(LikeArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAsTrackingAsyncBy(request.Id);
            if (article is null) return OperationResult.NotFound();

            article.Like(request.UserId);
            await _articleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}