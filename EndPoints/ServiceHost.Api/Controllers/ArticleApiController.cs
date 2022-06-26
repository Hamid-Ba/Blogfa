using Blogfa.Application.ArticleAgg.AddView;
using Blogfa.Application.ArticleAgg.ChangeStatus;
using Blogfa.Application.ArticleAgg.Create;
using Blogfa.Application.ArticleAgg.DisLike;
using Blogfa.Application.ArticleAgg.Edit;
using Blogfa.Application.ArticleAgg.Like;
using Blogfa.Presentation.Facade.ArticleAgg;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class ArticleApiController : BaseApiController
    {
        private readonly IArticleFacade _articleFacade;

        public ArticleApiController(IArticleFacade articleFacade) => _articleFacade = articleFacade;

        [HttpGet]
        public async Task<ApiResult<ArticleFilterResult>> GetAll([FromQuery]ArticleFilterParam filter) => QueryResult(await _articleFacade.GetAll(filter));

        [HttpGet("{id}")]
        public async Task<ApiResult<ArticleDto>> GetById(long id) => QueryResult(await _articleFacade.GetBy(id));

        [HttpGet("{slug}")]
        public async Task<ApiResult<ArticleDto>> GetBySlug(string slug) => QueryResult(await _articleFacade.GetBy(slug));

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateArticleCommand command) => CommandResult(await _articleFacade.Create(command));

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditArticleCommand command) => CommandResult(await _articleFacade.Edit(command));

        [HttpPut("changeStatus")]
        public async Task<ApiResult> ChangeStatus(ChangeStatusArticleCommand command) => CommandResult(await _articleFacade.ChangeStatus(command));

        [HttpPut("like")]
        public async Task<ApiResult> Like(LikeArticleCommand command) => CommandResult(await _articleFacade.Like(command));

        [HttpPut("disLike")]
        public async Task<ApiResult> DisLike(DisLikeArticleCommand command) => CommandResult(await _articleFacade.DisLike(command));

        [HttpPut("addView")]
        public async Task<ApiResult> AddView(AddViewArticleCommand command) => CommandResult(await _articleFacade.AddView(command));

    }
}