using System;
using Framework.Domain;
using Framework.Domain.ValueObjects;

namespace Blogfa.Domain.ArticleAgg
{
	public class Category : BaseEntity
	{
        public string Title { get;private set; }
        public string Slug { get;private set; }
        public SeoData SeoData { get;private set; }

        public List<Article> Articles { get; set; }

        public Category(string title, string slug, SeoData seoData)
        {
            Title = title;
            Slug = slug;
            SeoData = seoData;
            Articles = new List<Article>();
        }

        public void Edit(string title, string slug, SeoData seoData)
        {
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
    }
}

