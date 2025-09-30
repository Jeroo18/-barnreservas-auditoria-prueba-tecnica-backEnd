using Banreservas.ReservationHapiness.Application.Interfaces.Infrastructure;
using Banreservas.ReservationHapiness.Application.Models.Mail;
//using Banreservas.ReservationHapiness.Infrastructure.FileExport;
using Banreservas.ReservationHapiness.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banreservas.ReservationHapiness.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

           // services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
