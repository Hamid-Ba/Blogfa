using System;
using Blogfa.Presentation.Facade.ArticleAgg;
using Microsoft.Extensions.DependencyInjection;

namespace Blogfa.Presentation.Facade
{
    public static class Bootstrapper
    {
        public static void FacadeConfigure(this IServiceCollection services)
        {
            services.AddTransient<IArticleFacade, ArticleFacade>();
        }
    }
}