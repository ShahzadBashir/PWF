using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PWF.Persistence;
using PWF.Services.Email;
using PWF.Services.Settings;
using PWF.Services.PaymentGateway;
using PWF.Domain.Models;

namespace PWF.Web.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApplicationCookie(config => config.LoginPath = "/Account/Login");
            services.AddDbContext<PWFContext>(options => options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
           .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), providerOption => providerOption.EnableRetryOnFailure()).EnableSensitiveDataLogging(true));
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<PWFContext>();
            services.AddScoped<IPWFContext>(provider => provider.GetService<PWFContext>());
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IStripeService, StripeService>();
            services.Configure<EmailSettings>(configuration.GetSection("EMailSettings"));
            return services;

        }
    }
}
