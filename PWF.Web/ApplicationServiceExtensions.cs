using Microsoft.EntityFrameworkCore;
using PWF.Persistence;
using PWF.Services.Email;
using PWF.Services.Settings;

namespace PWF.Web.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PWFContext>(options => options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
           .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), providerOption => providerOption.EnableRetryOnFailure()).EnableSensitiveDataLogging(true));
            services.AddScoped<IPWFContext>(provider => provider.GetService<PWFContext>());
            services.AddScoped<IEmailService, EmailService>();
            services.Configure<EmailSettings>(configuration.GetSection("EMailSettings"));
            return services;

        }
    }
}
