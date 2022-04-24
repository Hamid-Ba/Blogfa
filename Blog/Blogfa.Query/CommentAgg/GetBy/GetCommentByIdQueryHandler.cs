using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.CommentAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.CommentAgg.GetBy
{
    public class GetCommentByIdQueryHandler : IBaseQueryHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly BlogfaContext _context;

        public GetCommentByIdQueryHandler(BlogfaContext context) => _context = context;

        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == request.Id);
            return comment.Map(_context);
        }
    }
}