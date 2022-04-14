using Blogfa.Domain.CommentAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.CommentAgg.Reject
{
    internal class RejectCommentCommandHandler : IBaseCommandHandler<RejectCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public RejectCommentCommandHandler(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public async Task<OperationResult> Handle(RejectCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsTrackingAsyncBy(request.Id);
            if (comment is null) return OperationResult.NotFound();

            comment.Reject();
            await _commentRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}