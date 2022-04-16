using Blogfa.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogfa.Infrastructure.EfCore.ArticleAgg
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles", "article");

            builder.HasKey(k => k.Id);
            builder.HasIndex(s => s.Slug);

            builder.Property(p => p.Slug).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(125).IsRequired();
            builder.Property(p => p.ImageName).HasMaxLength(225).IsRequired();
            builder.Property(p => p.Description).IsRequired();

            builder.OwnsOne(c => c.SeoData, config =>
           {
               config.Property(b => b.MetaDescription)
                   .HasMaxLength(500)
                   .HasColumnName("MetaDescription");

               config.Property(b => b.MetaTitle)
                   .HasMaxLength(500)
                   .HasColumnName("MetaTitle");

               config.Property(b => b.MetaKeyWords)
                   .HasMaxLength(500)
                   .HasColumnName("MetaKeyWords");
           });

            builder.OwnsOne(c => c.SeoImage, config =>
           {
               config.Property(c => c.Title).HasMaxLength(75).HasColumnName("ImageTitle");
               config.Property(c => c.Alternative).HasMaxLength(100).HasColumnName("ImageAlternative");
           });

            builder.OwnsMany(c => c.Likes, config =>
           {
               config.ToTable("Likes", "article");

               config.HasKey(k => k.Id);
           });
        }
    }
}