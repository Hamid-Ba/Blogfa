using Blogfa.Application.CommentAgg.Confirm;
using Blogfa.Application.CommentAgg.Create;
using Blogfa.Application.CommentAgg.Reject;
using Blogfa.Query.CommentAgg.DTOs;
using Blogfa.Query.CommentAgg.GetAll;
using Blogfa.Query.CommentAgg.GetBy;
using Framework.Application;
using MediatR;

namespace Blogfa.Presentation.Facade.CommentAgg
{
    public class CommentFacade : ICommentFacade
    {
        private readonly IMediator _mediator;

        public CommentFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Confirm(ConfirmCommentCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateCommentCommand command) => await _mediator.Send(command);

        public async Task<CommentFilterResult> GetAll(CommentFilterParam filter) => await _mediator.Send(new GetAllCommentQuery(filter));

        public async Task<CommentDto> GetBy(long id) => await _mediator.Send(new GetCommentByIdQuery(id));

        public async Task<OperationResult> Reject(RejectCommentCommand command) => await _mediator.Send(command);
    }
}