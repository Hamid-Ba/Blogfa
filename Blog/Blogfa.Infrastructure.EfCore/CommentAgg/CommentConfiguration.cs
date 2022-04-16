using Blogfa.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogfa.Infrastructure.EfCore.CommentAgg
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments", "comment");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Content).HasMaxLength(1250).IsRequired();
        }
    }
}