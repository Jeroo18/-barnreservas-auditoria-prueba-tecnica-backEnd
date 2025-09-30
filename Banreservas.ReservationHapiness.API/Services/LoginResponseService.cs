using Newtonsoft.Json;

namespace Banreservas.ReservationHapiness.API.Services
{
    public class LoginResponseService
    {
        public LoginResponseService()
        {

            this.Content = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("valid")]
        public string Valid { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("responseMsg")]
        public HttpResponseMessage responseMsg { get; set; }
    }
}
