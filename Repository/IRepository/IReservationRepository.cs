using Booking_ReservationAPI.Models;
using System.Linq.Expressions;

namespace Booking_ReservationAPI.Repository.IRepository
{
    public interface IReservationRepository:IRepository<Reservation>
    {
        
        Task <Reservation>UpdateAsync(Reservation entity);

       
         
    }
}
