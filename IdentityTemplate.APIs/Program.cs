using IdentityTemplate.APIs.Extensions;
using IdentityTemplate.Infrastructure.Persistence;
using IdentityTemplate.Core.Application;

namespace IdentityTemplate.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var WebApplicationbuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            WebApplicationbuilder.Services.AddControllers()
                .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly); //Register Reqiured Services By ASP.NET Core Web APIs To DI Container 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            WebApplicationbuilder.Services.AddEndpointsApiExplorer();
            WebApplicationbuilder.Services.AddSwaggerGen();

            //Extensions Services Layers 
            WebApplicationbuilder.Services.AddPersistenceServices(WebApplicationbuilder.Configuration);
            WebApplicationbuilder.Services.AddApplicationServices();


            // register for Identity [user manager]
            WebApplicationbuilder.Services.AddIdentityServices(WebApplicationbuilder.Configuration);




            var app = WebApplicationbuilder.Build();

            #region Database Initializer 

            await app.InitializeDbContext();

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
