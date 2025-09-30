using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banreservas.ReservationHapiness.Persistence.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ReservationHappinessDbContext dbContext) : base(dbContext)
        {
        }

        // Sobrescribir GetByIdAsync para usar int en lugar de Guid
        public override async Task<Reservation?> GetByIdAsync(Guid id)
        {
            // No usar este método, usar GetByIdAsync(int)
            throw new NotImplementedException("Use GetByIdAsync(int) instead");
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Reservation>().FindAsync(id);
        }

        public async Task<List<Reservation>> GetReservationsByDateAsync(DateTime date)
        {
            return await _dbContext.Set<Reservation>()
                .Where(r => r.ReservationDate.Date == date.Date)
                .OrderBy(r => r.ReservationTime)
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomerEmailAsync(string email)
        {
            return await _dbContext.Set<Reservation>()
                .Where(r => r.CustomerEmail.ToLower() == email.ToLower())
                .OrderByDescending(r => r.ReservationDate)
                .ToListAsync();
        }

        public async Task<bool> IsTableAvailableAsync(DateTime date, TimeSpan time)
        {
            var existingReservation = await _dbContext.Set<Reservation>()
                .Where(r => r.ReservationDate.Date == date.Date
                    && r.ReservationTime == time
                    && r.Status != ReservationStatus.Cancelled)
                .AnyAsync();

            return !existingReservation;
        }
    }
}