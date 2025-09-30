using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; } = string.Empty;
        public int NumberOfGuests { get; set; }
        public string? SpecialRequests { get; set; }
        public int Status { get; set; }
    }
}