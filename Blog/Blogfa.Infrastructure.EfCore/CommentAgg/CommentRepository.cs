using Blogfa.Domain.CommentAgg;
using Blogfa.Domain.CommentAgg.Repository;
using Framework.Infrastructure;

namespace Blogfa.Infrastructure.EfCore.CommentAgg
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
	{
		private readonly BlogfaContext _context;

		public CommentRepository(BlogfaContext context) : base(context) => _context = context;
	}
}