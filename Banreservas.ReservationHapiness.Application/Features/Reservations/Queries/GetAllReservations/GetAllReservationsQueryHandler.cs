using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using Banreservas.ReservationHapiness.Application.Interfaces.Persistence;
using MediatR;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Queries.GetAllReservations
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetAllReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.ListAllAsync();
            return _mapper.Map<List<ReservationDto>>(reservations);
        }
    }
}