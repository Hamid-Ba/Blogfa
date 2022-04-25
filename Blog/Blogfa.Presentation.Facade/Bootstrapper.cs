using Blogfa.Presentation.Facade.ArticleAgg;
using Blogfa.Presentation.Facade.CategoryAgg;
using Blogfa.Presentation.Facade.CommentAgg;
using Blogfa.Presentation.Facade.RoleAgg;
using Blogfa.Presentation.Facade.UserAgg;
using Microsoft.Extensions.DependencyInjection;

namespace Blogfa.Presentation.Facade
{
    public static class Bootstrapper
    {
        public static void FacadeConfigure(this IServiceCollection services)
        {
            services.AddTransient<IRoleFacade, RoleFacade>();
            services.AddTransient<IUserFacade, UserFacade>();
            services.AddTransient<IArticleFacade, ArticleFacade>();
            services.AddTransient<ICommentFacade, CommentFacade>();
            services.AddTransient<ICategoryFacade, CategoryFacade>();
        }
    }
}