using Blogfa.Domain.CommentAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.CommentAgg.Confirm
{
    internal class ConfirmCommentCommandHandler : IBaseCommandHandler<ConfirmCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public ConfirmCommentCommandHandler(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public async Task<OperationResult> Handle(ConfirmCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsTrackingAsyncBy(request.Id);
            if (comment is null) return OperationResult.NotFound();

            comment.Confirm();
            await _commentRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}