using Core.Domain.Contracts.Persistence.DbInitializers;
using IdentityTemplate.Infrastructure.Persistence.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IdentityTemplate.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services , IConfiguration configuration)
        {
           
           
          

            #region IdentityContext And IdentityInitializer

            services.AddDbContext<IdentityDbContext>(options =>
            {
                options
                //.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("IdentityContext"));
            });

            //
            services.AddScoped(typeof(IIdentityDbInitializer), typeof(IdentityDbInitializer));

            #endregion

           


             
            return services;
        }
    
    }
}
