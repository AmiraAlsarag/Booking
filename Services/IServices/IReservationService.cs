using Booking_web.Models.Dto;

namespace Booking_web.Services.IServices
{
    public interface IReservationService 
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ReservationCreateDTO dto );
        Task<T> UpdateAsync<T>(ReservationUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
	}
}
