using System;
using Blogfa.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace Blogfa.Infrastructure.EfCore
{
	public class BlogfaContext : DbContext
	{
		public BlogfaContext(DbContextOptions<BlogfaContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            var assembly = typeof(BlogfaContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<Article>().HasQueryFilter(p => !p.IsDelete);
        }

        public Article Article { get; set; }
    }
}