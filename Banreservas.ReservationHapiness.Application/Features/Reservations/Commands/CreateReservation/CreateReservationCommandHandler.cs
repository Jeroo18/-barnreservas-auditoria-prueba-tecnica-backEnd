using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using Banreservas.ReservationHapiness.Domain.Entities;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                ReservationDate = request.ReservationDate,
                ReservationTime = TimeSpan.Parse(request.ReservationTime),
                NumberOfGuests = request.NumberOfGuests,
                SpecialRequests = request.SpecialRequests,
                Status = ReservationStatus.Pending
            };

            reservation = await _reservationRepository.AddAsync(reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}