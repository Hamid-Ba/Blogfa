using Blogfa.Application.ArticleAgg;
using Blogfa.Application.CategoryAgg;
using Blogfa.Application.RoleAgg;
using Blogfa.Application.UserAgg;
using Blogfa.Domain.ArticleAgg.Services;
using Blogfa.Domain.CategoryAgg.Services;
using Blogfa.Domain.RoleAgg.Services;
using Blogfa.Domain.UserAgg.Services;
using Blogfa.Infrastructure.EfCore;
using Blogfa.Presentation.Facade;
using Blogfa.Query.ArticleAgg;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blogfa.Infrastructure.Configuration
{
    public static class Bootstrapper
	{
		public static void Configuration(this IServiceCollection services,string connectionString)
        {
            //Add Repositories Dependencies
            services.EfCoreConfiure(connectionString);

            //Configure Commands
            services.AddMediatR(typeof(ArticleDomainService).Assembly);

            //Configure Queries
            services.AddMediatR(typeof(ArticleMapper).Assembly);

            //Configure Validation
            services.AddValidatorsFromAssembly(typeof(ArticleDomainService).Assembly);

            //Configure Facade
            services.FacadeConfigure();

            //Configure Domain Service
            services.AddTransient<IArticleDomainService, ArticleDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<IRoleDomainService, RoleDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
        }
	}
}