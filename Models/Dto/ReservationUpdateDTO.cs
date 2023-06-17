using System.ComponentModel.DataAnnotations;

namespace Booking_ReservationAPI.Models.Dto
{
    public class ReservationUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        //user asked for reservation ,manually entered
        public string CustomerName { get; set; }

        //admin name
        public string ReservedBy { get; set; }

        public DateTime ReservationDate { get; set; }


        //Trip
        public int Trip_Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }

    }
}
