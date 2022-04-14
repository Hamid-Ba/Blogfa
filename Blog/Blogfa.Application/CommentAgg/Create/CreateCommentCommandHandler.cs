using Blogfa.Domain.CommentAgg;
using Blogfa.Domain.CommentAgg.Repository;
using Framework.Application;

namespace Blogfa.Application.CommentAgg.Create
{
    internal class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId, request.ArticleId, request.Content);

            await _commentRepository.AddEntityAsync(comment);
            await _commentRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}