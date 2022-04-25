using System;
using Blogfa.Presentation.Facade.ArticleAgg;
using Blogfa.Presentation.Facade.CategoryAgg;
using Blogfa.Presentation.Facade.CommentAgg;
using Microsoft.Extensions.DependencyInjection;

namespace Blogfa.Presentation.Facade
{
    public static class Bootstrapper
    {
        public static void FacadeConfigure(this IServiceCollection services)
        {
            services.AddTransient<IArticleFacade, ArticleFacade>();
            services.AddTransient<ICategoryFacade, CategoryFacade>();
            services.AddTransient<ICommentFacade, CommentFacade>();
        }
    }
}