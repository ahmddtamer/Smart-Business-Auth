using IdentityTemplate.Core.Application.Abstraction.Services;
using IdentityTemplate.Core.Application.Abstraction.Services.Auth;
using IdentityTemplate.Core.Application.Services;
using IdentityTemplate.Core.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityTemplate.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            // Service Manager
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
              
            // BasketService
            services.AddScoped<IAuthService, AuthService>();

           

            return services;
        }

    }
}
