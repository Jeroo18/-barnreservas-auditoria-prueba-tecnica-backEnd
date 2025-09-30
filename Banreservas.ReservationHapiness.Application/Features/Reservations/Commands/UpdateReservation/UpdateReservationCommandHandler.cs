using AutoMapper;
using Banreservas.ReservationHapiness.Application.Exceptions;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationToUpdate = await _reservationRepository.GetByIdAsync(request.Id);

            if (reservationToUpdate == null)
            {
                throw new NotFoundException(nameof(Reservation), request.Id);
            }

            reservationToUpdate.CustomerName = request.CustomerName;
            reservationToUpdate.CustomerEmail = request.CustomerEmail;
            reservationToUpdate.CustomerPhone = request.CustomerPhone;
            reservationToUpdate.ReservationDate = request.ReservationDate;
            reservationToUpdate.ReservationTime = TimeSpan.Parse(request.ReservationTime);
            reservationToUpdate.NumberOfGuests = request.NumberOfGuests;
            reservationToUpdate.SpecialRequests = request.SpecialRequests;
            reservationToUpdate.Status = (ReservationStatus)request.Status;

            await _reservationRepository.UpdateAsync(reservationToUpdate);

            return Unit.Value;
        }
    }
}