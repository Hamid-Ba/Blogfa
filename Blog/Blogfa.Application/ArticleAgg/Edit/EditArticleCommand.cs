using System;
using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Blogfa.Application.ArticleAgg.Edit
{
    public record EditArticleCommand(long Id,string Title, long CategoryId, string Slug, IFormFile ImageFile ,string ImageName, SeoImage SeoImage,
			string Description, SeoData SeoData, DateTime PublishDate) : IBaseCommand;
}