using Banreservas.ReservationHapiness.Application.Models.Mail;
using System.Threading.Tasks;

namespace Banreservas.ReservationHapiness.Application.Interfaces.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
