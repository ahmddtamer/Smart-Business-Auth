using IdentityTemplate.Core.Application.Abstraction.Services.Auth;

namespace IdentityTemplate.Core.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        public IAuthService AuthService { get; }



    }
}
