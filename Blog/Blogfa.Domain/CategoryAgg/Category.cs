using Blogfa.Domain.CategoryAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Blogfa.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }

        private Category() { }

        public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
        {
            Guard(title, slug, categoryService);

            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
        {
            Guard(title, slug, categoryService);

            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        private void Guard(string title, string slug, ICategoryDomainService categoryService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (categoryService.IsSlugExist(slug))
                throw new InvalidDomainDataException("This Slug Has Already Exist");
        }
    }
}