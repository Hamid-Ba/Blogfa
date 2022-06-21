using Blogfa.Application.CommentAgg.Create;
using Blogfa.Presentation.Facade.CommentAgg;
using Blogfa.Query.CommentAgg.DTOs;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class CommentApiController : BaseApiController
    {
        private readonly ICommentFacade _commentFacade;

        public CommentApiController(ICommentFacade commentFacade) => _commentFacade = commentFacade;

        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetAll([FromQuery] CommentFilterParam filter) => QueryResult(await _commentFacade.GetAll(filter));

        [HttpGet("{id}")]
        public async Task<ApiResult<CommentDto>> GetBy(long id) => QueryResult(await _commentFacade.GetBy(id));

        [HttpPost]
        public async Task<ApiResult> Create(CreateCommentCommand command) => CommandResult(await _commentFacade.Create(command));
    }
}