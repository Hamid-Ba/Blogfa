﻿using Blogfa.Domain.ArticleAgg;
using Blogfa.Domain.CategoryAgg;
using Blogfa.Domain.CommentAgg;
using Blogfa.Domain.RoleAgg;
using Blogfa.Domain.UserAgg;
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
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDelete);
            modelBuilder.Entity<Comment>().HasQueryFilter(p => !p.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDelete);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDelete);
        }

        public Article Article { get; set; }
        public Category Category { get; set; }
        public Comment Comment { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}