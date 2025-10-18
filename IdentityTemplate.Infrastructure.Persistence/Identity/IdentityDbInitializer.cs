using Core.Domain.Contracts.Persistence.DbInitializers;
using Core.Domain.Entities.Identity;
using IdentityTemplate.Infrastructure.Persistence.Common;
using Microsoft.AspNetCore.Identity;

namespace IdentityTemplate.Infrastructure.Persistence.Identity
{
    public class IdentityDbInitializer(
        IdentityDbContext dbContext,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> _roleManager
        )
        : DbInitializer(dbContext), IIdentityDbInitializer
    {
      

        public override async Task SeedAsync()
        {

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }


            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    DisplayName = "Ahmed Tamer",
                    UserName = "AhmedTamer",
                    Email = "AhmedTamer@gmail.com",
                    PhoneNumber = "01242374632"
                };
                var user2 = new ApplicationUser()
                {
                    Email = "Salma@gmail.com",
                    DisplayName = "Salma Mohamed",
                    PhoneNumber = "0123456789",
                    UserName = "SalmaMohamed",
                };

                await userManager.CreateAsync(user, "P@ssw0rd");

                await userManager.CreateAsync(user2, "P@ssW0rd02");

                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user2, "SuperAdmin");

            }
        }
    }
}
