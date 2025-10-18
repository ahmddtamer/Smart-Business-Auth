using Core.Domain.Entities.Identity;
using IdentityTemplate.Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace IdentityTemplate.APIs.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration configuration)
        {

             services.AddIdentity<ApplicationUser, IdentityRole>(identityOptions =>
             {
                    // For User
                    identityOptions.User.RequireUniqueEmail = true;

                    // For SignIn
                    // identityOptions.SignIn.RequireConfirmedEmail = true;
                    // identityOptions.SignIn.RequireConfirmedAccount = true;
                    // identityOptions.SignIn.RequireConfirmedPhoneNumber = true;

                    // For Password
                    // identityOptions.Password.RequireNonAlphanumeric = true;
                    // identityOptions.Password.RequiredUniqueChars = 2;
                    // identityOptions.Password.RequiredLength= 6;
                    // identityOptions.Password.RequireUppercase = true;
                    // identityOptions.Password.RequireLowercase = true;
                    // identityOptions.Password.RequireDigit = true;
             })
               .AddEntityFrameworkStores<IdentityDbContext>();

                        
            return services;    
        }
    }
}
