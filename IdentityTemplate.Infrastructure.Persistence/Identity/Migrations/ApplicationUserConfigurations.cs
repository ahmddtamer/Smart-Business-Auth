using Core.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityTemplate.Infrastructure.Persistence.Identity.Migrations
{

    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.DisplayName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(true);

           
        }
    }
}
