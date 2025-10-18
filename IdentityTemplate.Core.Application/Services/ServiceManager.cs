using IdentityTemplate.Core.Application.Abstraction.Services;
using IdentityTemplate.Core.Application.Abstraction.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityTemplate.Core.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        
        private readonly IServiceProvider _serviceProvider; // For Basket Service To Generate other DI for it
        private readonly Lazy<IAuthService> _authService;



        public ServiceManager(
            IServiceProvider serviceProvider
            )
        {
           
            _serviceProvider = serviceProvider;
            _authService = new Lazy<IAuthService>(() => _serviceProvider.GetRequiredService<IAuthService>());

        }


        public IAuthService AuthService => _authService.Value;

    }
}
