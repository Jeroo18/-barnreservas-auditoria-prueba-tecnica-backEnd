using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<ReservationDto>
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; } = string.Empty;
        public int NumberOfGuests { get; set; }
        public string? SpecialRequests { get; set; }
    }
}