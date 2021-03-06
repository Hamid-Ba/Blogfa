using Blogfa.Domain.ArticleAgg;
using Blogfa.Infrastructure.EfCore;
using Blogfa.Query.ArticleAgg.DTOs;
using Framework.Application;

namespace Blogfa.Query.ArticleAgg
{
    public static class ArticleMapper
    {
        public static ArticleDto Map(this Article article, BlogfaContext context)
        {
            if (article is null) return null!;

            var user = context.User.Select(u => new { Id = u.Id, FullName = $"{u.FirstName} {u.LastName}" })
                .FirstOrDefault(u => u.Id == article.UserId);

            var category = context.Category.Select(c => new ArticleCategoryDto
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug
            }).FirstOrDefault(c => c.Id == article.CategoryId);

            return new ArticleDto
            {
                Id = article.Id,
                UserId = article.UserId,
                UserFullName = user!.FullName,
                Slug = article.Slug,
                Title = article.Title,
                ImageName = article.ImageName,
                Description = article.Description,
                ViewerCount = article.ViewerCount,
                //SeoData = article.SeoData,
                //SeoImage = article.SeoImage,
                Likes = MapLikes(article.Likes),
                Category = category!,
                CreationDate = article.CreationDate,
                GeorgianPublishDate = article.PublishDate,
                PublishDate = article.PublishDate.ToFarsi(),
                Status = article.Status,
                StatusDescription = article.StatusDescription
            };
        }

        public static ArticleDto MapResult(this Article article)
        {
            if (article is null) return null!;

            //var user = context.User.Select(u => new { Id = u.Id, FullName = $"{u.FirstName} {u.LastName}" })
            //    .FirstOrDefault(u => u.Id == article.UserId);

            //var category = context.Category.Select(c => new ArticleCategoryDto
            //{
            //    Id = c.Id,
            //    Title = c.Title,
            //    Slug = c.Slug
            //}).FirstOrDefault(c => c.Id == article.CategoryId);

            return new ArticleDto
            {
                Id = article.Id,
                UserId = article.UserId,
                Category = new ArticleCategoryDto { Id = article.CategoryId},
                //UserFullName = user!.FullName,
                Slug = article.Slug,
                Title = article.Title,
                ImageName = article.ImageName,
                ViewerCount = article.ViewerCount,
                //SeoImage = article.SeoImage,
                //Likes = MapLikes(article.Likes),
                //Category = category!,
                GeorgianPublishDate = article.PublishDate,
                PublishDate = article.PublishDate.ToFarsi(),
                Status = article.Status,
                StatusDescription = article.StatusDescription
            };
        }

        private static List<ArticleLikeDto> MapLikes(this List<Like> likes) => likes.Select(l => new ArticleLikeDto
        {
            Id = l.Id,
            ArtileId = l.ArticleId,
            UserId = l.UserId
        }).ToList();
    }
}