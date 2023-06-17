using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_ReservationAPI.Models
{
    public class Reservation 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ReservedBy { get; set; }

        public string CustomerName { get; set; }

        //Trip
        //[ForeignKey("Trip")]
        public int Trip_Id { get; set; }
        
        //public Trip Trip { get; set; } 
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }

        //admin name


    }
}
