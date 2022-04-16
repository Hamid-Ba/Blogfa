using Blogfa.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogfa.Infrastructure.EfCore.CategoryAgg
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "category");

            builder.HasKey(k => k.Id);
            builder.HasIndex(s => s.Slug);

            builder.Property(p => p.Slug).HasMaxLength(160).IsRequired();
            builder.Property(p => p.Title).HasMaxLength(80).IsRequired();

            builder.OwnsOne(s => s.SeoData, config =>
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
        }
    }
}