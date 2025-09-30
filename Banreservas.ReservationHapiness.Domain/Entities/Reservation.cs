using Banreservas.ReservationHapiness.Domain.Common;

namespace Banreservas.ReservationHapiness.Domain.Entities
{
    public class Reservation : AuditableEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string? SpecialRequests { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }

    public enum ReservationStatus
    {
        Pending = 0,
        Confirmed = 1,
        Cancelled = 2,
        Completed = 3,
        NoShow = 4
    }
}