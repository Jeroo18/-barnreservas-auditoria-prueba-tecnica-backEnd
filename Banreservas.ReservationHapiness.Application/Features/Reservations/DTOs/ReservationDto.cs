using Banreservas.ReservationHapiness.Domain.Entities;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; } = string.Empty;
        public int NumberOfGuests { get; set; }
        public string? SpecialRequests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}