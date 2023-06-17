
using AutoMapper;
using Booking_ReservationAPI.Models;
using Booking_ReservationAPI.Models.Dto;

namespace Booking_ReservationAPI
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Reservation,ReservationDTO>().ReverseMap();
            CreateMap<Reservation, ReservationUpdateDTO>().ReverseMap();
            CreateMap<Reservation, ReservationCreateDTO>().ReverseMap();

        }
    }
}
