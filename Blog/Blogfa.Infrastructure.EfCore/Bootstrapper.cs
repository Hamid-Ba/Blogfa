using System;
using Blogfa.Domain.ArticleAgg.Repository;
using Blogfa.Domain.CategoryAgg.Repository;
using Blogfa.Domain.CommentAgg.Repository;
using Blogfa.Domain.RoleAgg.Repository;
using Blogfa.Domain.UserAgg.Repository;
using Blogfa.Infrastructure.EfCore.ArticleAgg;
using Blogfa.Infrastructure.EfCore.CategoryAgg;
using Blogfa.Infrastructure.EfCore.CommentAgg;
using Blogfa.Infrastructure.EfCore.RoleAgg;
using Blogfa.Infrastructure.EfCore.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blogfa.Infrastructure.EfCore
{
	public static class Bootstrapper
	{
		public static void EfCoreConfiure(this IServiceCollection services , string connectionString)
        {
			services.AddDbContext<BlogfaContext>(c => c.UseSqlServer(connectionString));

			services.AddTransient<IArticleRepository, ArticleRepository>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<ICommentRepository, CommentRepository>();
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
		}
	}
}