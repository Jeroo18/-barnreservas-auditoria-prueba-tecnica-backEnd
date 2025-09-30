using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetAllReservations
{
    public class GetAllReservationsQuery : IRequest<List<ReservationDto>>
    {
    }
}