using Core.Domain.Contracts.Persistence.DbInitializers;

namespace IdentityTemplate.APIs.Extensions
{
    public static class InitializerExtensions
    {
        // generate Object From DbInitializer Explicitly
        public static async Task<WebApplication> InitializeDbContext(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            
            var IdentityInitializer = services.GetRequiredService<IIdentityDbInitializer>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await IdentityInitializer.InitializeAsync();
                await IdentityInitializer.SeedAsync();

            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Has Been Occured during applying the migrations !");

            }
           
            return app;

        }
    }
}
