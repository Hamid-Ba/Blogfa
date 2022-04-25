using Blogfa.Presentation.Facade.ArticleAgg;
using Blogfa.Presentation.Facade.CategoryAgg;
using Blogfa.Presentation.Facade.CommentAgg;
using Blogfa.Presentation.Facade.RoleAgg;
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
            services.AddTransient<IRoleFacade, RoleFacade>();
        }
    }
}