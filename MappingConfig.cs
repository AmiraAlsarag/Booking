
using AutoMapper;
using Booking_web.Models.Dto;

namespace Booking_web
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<ReservationDTO, ReservationUpdateDTO>().ReverseMap();
            CreateMap<ReservationDTO, ReservationCreateDTO>().ReverseMap();

        }
    }
}
