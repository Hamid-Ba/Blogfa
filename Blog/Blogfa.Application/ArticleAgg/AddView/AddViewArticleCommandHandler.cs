using Blogfa.Domain.ArticleAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.ArticleAgg.AddView
{
    internal class AddViewArticleCommandHandler : IBaseCommandHandler<AddViewArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public AddViewArticleCommandHandler(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        public async Task<OperationResult> Handle(AddViewArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetAsTrackingAsyncBy(request.Id);
            if (article is null) return OperationResult.NotFound();

            article.AddView();
            await _articleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}