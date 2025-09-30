using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}