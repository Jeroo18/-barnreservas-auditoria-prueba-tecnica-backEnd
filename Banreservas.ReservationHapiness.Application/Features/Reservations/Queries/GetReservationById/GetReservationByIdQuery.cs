using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetReservationById
{
    public class GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public int Id { get; set; }
    }
}