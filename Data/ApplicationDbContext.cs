using Booking_ReservationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking_ReservationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options) 
        { }
        public DbSet<Reservation> Reservations { get; set; }
      

        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }




        //seed Reservation table 
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Reservation>().HasData(
        //        new Reservation
        //        {
        //            Id = 1,
        //            CreationDate = DateTime.Now,
        //            ReservationDate = DateTime.Now,
        //            CustomerName = "fayrouz",
        //            Notes = "baby",
        //            ReservedBy = "mamadmin",
        //            Trip_Id = 1
        //        });  }

        
        
        

    }
}
