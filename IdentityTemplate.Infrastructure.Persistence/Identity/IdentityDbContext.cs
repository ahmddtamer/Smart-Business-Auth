using Core.Domain.Entities.Identity;
using IdentityTemplate.Infrastructure.Persistence.Identity.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace IdentityTemplate.Infrastructure.Persistence.Identity
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Must Keep It

            builder.ApplyConfiguration(new ApplicationUserConfigurations());


        }

    }
}
