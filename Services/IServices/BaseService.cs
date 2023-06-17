using Booking_Utility;
using Booking_web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Booking_web.Services.IServices
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }

        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new APIResponse();
            this.httpClient = httpClient;

        }
        public async Task<T>SendAsync<T>(APIRequest apiRequest)
        {
            try
            { 
                var client=httpClient.CreateClient("ReservationAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri=new Uri(apiRequest.Url);
                if(apiRequest.Data!=null)
                {
                    message.Content=new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,"application/json");
                }
                switch(apiRequest.Apitype)
                {
                    case DS.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case DS.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case DS.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                       
                }
                HttpResponseMessage apiResponse = null;
                apiResponse=await client.SendAsync(message);
                var apiContent= await apiResponse.Content.ReadAsStringAsync();
                var APIResponse=JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
                }

            catch (Exception ex) 
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res=JsonConvert.SerializeObject(dto);
                var APIResponse= JsonConvert.DeserializeObject<T>(res);
                return APIResponse;

            }
        }
    }
}
