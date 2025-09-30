using Banreservas.ReservationHapiness.Domain.Entities;

namespace Banreservas.ReservationHapiness.Application.Interfaces.Persistence
{
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
        Task<Reservation?> GetByIdAsync(int id);
        Task<List<Reservation>> GetReservationsByDateAsync(DateTime date);
        Task<List<Reservation>> GetReservationsByCustomerEmailAsync(string email);
        Task<bool> IsTableAvailableAsync(DateTime date, TimeSpan time);
    }
}