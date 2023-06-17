using Booking_Utility;
using Booking_web.Models;
using Booking_web.Models.Dto;

namespace Booking_web.Services.IServices
{
    public class ReservationService : BaseService, IReservationService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string reservationUrl;
        public ReservationService(IHttpClientFactory clientFactory,IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            reservationUrl = configuration.GetValue<string>("ServiceUrls:ReservationAPI");
        }

        public Task<T> CreateAsync<T>(ReservationCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                 Apitype=DS.ApiType.POST,
                 Data=dto,
                 Url=reservationUrl+ "/api/ReservationAPI"
            }
                );
        }

		

		public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Apitype = DS.ApiType.DELETE,
                Url = reservationUrl + "/api/ReservationAPI"+id
            }
                            );
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Apitype = DS.ApiType.GET,
                Url = reservationUrl + "/api/ReservationAPI" 
            }
                                        );
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Apitype = DS.ApiType.GET,
                Url = reservationUrl + "/api/ReservationAPI" + id
            }
                                        );
        }

        public Task<T> UpdateAsync<T>(ReservationUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Apitype = DS.ApiType.PUT,
                Data = dto,
                Url = reservationUrl + "/api/ReservationAPI/"+dto.Id
            }
                           );
        }
    }
}
