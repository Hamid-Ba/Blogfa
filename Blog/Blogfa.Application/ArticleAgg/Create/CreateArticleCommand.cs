using System;
using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Blogfa.Application.ArticleAgg.Create
{
    public record CreateArticleCommand(string Title, long UserId, long CategoryId, string Slug, IFormFile ImageFile, SeoImage SeoImage,
            string Description, SeoData SeoData) : IBaseCommand;
}