namespace Booking_ReservationAPI.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

        
        // accepting html format
        public DateTime CreationDate { get; set; }
        

    }
}
