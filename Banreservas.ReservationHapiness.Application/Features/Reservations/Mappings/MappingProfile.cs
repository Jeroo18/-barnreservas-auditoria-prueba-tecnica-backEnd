using AutoMapper;
using Banreservas.ReservationHapiness.Application.Features.Reservations.DTOs;
using Banreservas.ReservationHapiness.Domain.Entities;

namespace Banreservas.ReservationHapiness.Application.Features.Reservations.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.ReservationTime, opt => opt.MapFrom(src => src.ReservationTime.ToString(@"hh\:mm")))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateReservationDto, Reservation>()
                .ForMember(dest => dest.ReservationTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.ReservationTime)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ReservationStatus.Pending));

            CreateMap<UpdateReservationDto, Reservation>()
                .ForMember(dest => dest.ReservationTime, opt => opt.MapFrom(src => TimeSpan.Parse(src.ReservationTime)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ReservationStatus)src.Status));
        }
    }
}