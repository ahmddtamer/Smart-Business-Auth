using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public required string DisplayName { get; set; }
    }
}
