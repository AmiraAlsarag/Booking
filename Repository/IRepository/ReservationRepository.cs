using Booking_ReservationAPI.Data;
using Booking_ReservationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking_ReservationAPI.Repository.IRepository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _db;
        public ReservationRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
       
        public async Task<Reservation> UpdateAsync(Reservation entity)
        {
          
            _db.Reservations.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
