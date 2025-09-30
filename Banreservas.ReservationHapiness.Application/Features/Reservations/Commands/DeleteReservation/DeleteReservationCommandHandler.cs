using Banreservas.ReservationHapiness.Application.Exceptions;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationToDelete = await _reservationRepository.GetByIdAsync(request.Id);

            if (reservationToDelete == null)
            {
                throw new NotFoundException(nameof(Reservation), request.Id);
            }

            await _reservationRepository.DeleteAsync(reservationToDelete);

            return Unit.Value;
        }
    }
}