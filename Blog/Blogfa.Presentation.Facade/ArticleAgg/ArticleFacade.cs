using Blogfa.Application.ArticleAgg.AddView;
using Blogfa.Application.ArticleAgg.ChangeStatus;
using Blogfa.Application.ArticleAgg.Create;
using Blogfa.Application.ArticleAgg.DisLike;
using Blogfa.Application.ArticleAgg.Edit;
using Blogfa.Application.ArticleAgg.Like;
using Blogfa.Query.ArticleAgg.DTOs;
using Blogfa.Query.ArticleAgg.GetAll;
using Blogfa.Query.ArticleAgg.GetAllForAdmin;
using Blogfa.Query.ArticleAgg.GetById;
using Blogfa.Query.ArticleAgg.GetBySlug;
using Framework.Application;
using MediatR;

namespace Blogfa.Presentation.Facade.ArticleAgg
{
    public class ArticleFacade : IArticleFacade
    {
        private readonly IMediator _mediator;

        public ArticleFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> AddView(AddViewArticleCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChangeStatus(ChangeStatusArticleCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateArticleCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> DisLike(DisLikeArticleCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditArticleCommand command) => await _mediator.Send(command);

        public async Task<ArticleFilterResult> GetAll(ArticleFilterParam filter) => await _mediator.Send(new GetAllArticlesQuery(filter));

        public async Task<List<ArticleDto>> GetAllForAdmin() => await _mediator.Send(new GetAllForAdminArticleQuery());

        public async Task<ArticleDto> GetBy(long id) => await _mediator.Send(new GetArticleByIdQuery(id));

        public async Task<ArticleDto> GetBy(string slug) => await _mediator.Send(new GetArticleBySlugQuery(slug));

        public async Task<OperationResult> Like(LikeArticleCommand command) => await _mediator.Send(command);
    }
}