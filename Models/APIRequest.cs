using static Booking_Utility.DS;

namespace Booking_web.Models
{
    public class APIRequest
    {

        public ApiType Apitype { get; set; } = ApiType.GET;
        public string Url { get; set; }

        public Object Data { get; set; }




    }
}
