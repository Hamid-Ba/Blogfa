using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.CommentAgg.DTOs;
using Framework.Query;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Query.CommentAgg.GetAll
{
    public class GetAllCommentQueryHandler : IBaseQueryHandler<GetAllCommentQuery, CommentFilterResult>
    {
        private readonly BlogfaContext _context;

        public GetAllCommentQueryHandler(BlogfaContext context) => _context = context;

        public async Task<CommentFilterResult> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var comments = _context.Comment.OrderByDescending(c => c.Id).AsQueryable();
            var users =  _context.User.Select(u => new { Id = u.Id, FullName = $"{u.FirstName} {u.LastName}", Phone = u.PhoneNumber }).ToList();
            var articles =  _context.Article.Select(a => new { Id = a.Id, Title = a.Title }).ToList();

            if (!string.IsNullOrWhiteSpace(@params.UserFullName))
            {
                users = users.Where(u => u.FullName.Contains(@params.UserFullName)).ToList();
                comments = comments.Where(c => users.Where(u => c.UserId == u.Id).FirstOrDefault().Id == c.UserId);
            }

            if (!string.IsNullOrWhiteSpace(@params.UserPhone))
            {
                users = users.Where(u => u.Phone.Contains(@params.UserPhone)).ToList();
                comments = comments.Where(c => users.Where(u => c.UserId == u.Id).FirstOrDefault().Id == c.UserId);
            }

            if(!string.IsNullOrWhiteSpace(@params.ArticleTitle))
            {
                articles = articles.Where(a => a.Title.Contains(@params.ArticleTitle)).ToList();
                comments = comments.Where(c => articles.Where(a => c.ArticleId == a.Id).FirstOrDefault().Id == c.UserId);
            }

            var skip = (@params.PageId - 1) * @params.Take;

            var result = new CommentFilterResult
            {
                FilterParams = request.FilterParams,
                Data = await comments.Skip(skip).Take(@params.Take).Select(c => c.MapResult(_context)).ToListAsync()
            };

            result.GeneratePaging(comments, @params.Take, @params.PageId);

            return result;
        }
    }
}