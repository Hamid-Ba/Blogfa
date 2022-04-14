using Blogfa.Domain.ArticleAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Blogfa.Domain.ArticleAgg
{
    public class Article : AggregateRoot
    {
        public string Title { get; private set; }
        public long UserId { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string Image { get; private set; }
        public SeoImage SeoImage { get; private set; }
        public string Description { get; private set; }
        public SeoData SeoData { get; private set; }
        public int ViewerCount { get; private set; }

        public List<Like> Likes { get; set; }

        private Article() { }

        public Article(string title, long userId, long categoryId, string slug, string image, SeoImage seoImage,
            string description, SeoData seoData, IArticleDomainService articleService)
        {
            Guard(title, description, slug, articleService);

            Title = title;
            UserId = userId;
            CategoryId = categoryId;
            Slug = slug;
            Image = image;
            SeoImage = seoImage;
            Description = description;
            SeoData = seoData;
            ViewerCount = 0;
            Likes = new();
        }

        public void Edit(string title, long categoryId, string slug, string image, SeoImage seoImage,
            string description, SeoData seoData, IArticleDomainService articleService)
        {
            Guard(title, description, slug, articleService);

            Title = title;
            CategoryId = categoryId;
            Slug = slug;

            if (!string.IsNullOrWhiteSpace(image))
                Image = image;

            SeoImage = seoImage;
            Description = description;
            SeoData = seoData;
        }

        public void AddView() => ViewerCount++;

        #region Like

        public void Like(long userId)
        {
            var isLikeExist = Likes.Any(l => l.UserId == userId);
            if (isLikeExist) throw new InvalidDomainDataException("This User Has Already Liked This Article");

            var like = new Like(userId);
            like.ArticleId = Id;

            Likes.Add(like);
        }

        public void DissLike(long userId)
        {
            var isLikeExist = Likes.Any(l => l.UserId == userId);
            if (isLikeExist) throw new InvalidDomainDataException("This User Hasn't Liked This Article at All");

            var like = Likes.FirstOrDefault(l => l.UserId == userId);
            if (like != null)
                Likes.Remove(like);
        }

        #endregion

        private void Guard(string title, string description, string slug, IArticleDomainService articleService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));

            if (articleService.IsSlugExist(slug))
                throw new InvalidDomainDataException("This Slug Exists");
        }

    }
}