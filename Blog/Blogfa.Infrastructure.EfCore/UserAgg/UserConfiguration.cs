using Blogfa.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogfa.Infrastructure.EfCore.UserAgg
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "users");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.FirstName).HasMaxLength(75).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(82).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(225).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Avatar).HasMaxLength(150);

            builder.OwnsMany(r => r.Roles, config =>
           {
               config.ToTable("Role", "users");

               config.HasKey(k => k.Id);
           });
        }
    }
}