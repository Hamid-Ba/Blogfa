using Blogfa.Domain.CommentAgg;
using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.CommentAgg.DTOs;

namespace Blogfa.Query.CommentAgg
{
    public static class CommentMapper
	{
		public static CommentDto MapResult(this Comment comment,BlogfaContext context)
        {
			if (comment is null) return null;

			var user = context.User.Where(u => u.Id == comment.UserId)
				.Select(u => new { FullName = $"{u.FirstName} {u.LastName}", Phone = u.PhoneNumber })
				.FirstOrDefault();

			var article = context.Article.Where(u => u.Id == comment.ArticleId)
				.Select(u => new { Title = u.Title})
				.FirstOrDefault();

			return new CommentDto
			{
				Id = comment.Id,
				ArticleId = comment.ArticleId,
				ArticleTitle = article.Title,
				UserId = comment.UserId,
				UserFullName = user.FullName,
				UserPhone = user.Phone,
				IsConfirm = comment.IsConfirm,
				CreationDate = comment.CreationDate
			};
        }
	}
}