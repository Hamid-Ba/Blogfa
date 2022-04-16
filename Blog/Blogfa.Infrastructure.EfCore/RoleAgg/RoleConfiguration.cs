using Blogfa.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogfa.Infrastructure.EfCore.RoleAgg
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(75).IsRequired();

            builder.OwnsMany(p => p.Permissions, config =>
           {
               config.ToTable("Permissions", "role");

               config.HasKey(k => k.Id);
           });
        }
    }
}