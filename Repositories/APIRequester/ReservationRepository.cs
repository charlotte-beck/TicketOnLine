using G = Global;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Repositories.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using Newtonsoft.Json;
using Repositories.Data.Mappers;
using System.Linq;

namespace Repositories.APIRequester
{
    public class ReservationRepository : IReservationAPIRequester<Reservation, Reservation_User_Event>
    {
        private readonly HttpClient _httpClient;
        public ReservationRepository(string url)
        {
            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Default
            };

            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
            {
                return true;
            };

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Reservation CreateReservation(Reservation entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity.ToGlobal()));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PostAsync("reservation", content).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Reservation>(json).ToClient();
        }

        public IEnumerable<Reservation_User_Event> GetAllByEvent(int eventId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"reservation/event/{eventId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<G.Reservation_User_Event[]>(json).Select(ev => ev.ToClient());
        }

        public IEnumerable<Reservation_User_Event> GetAllByUser(int userId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"reservation/user/{userId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<G.Reservation_User_Event[]>(json).Select(ev => ev.ToClient());
        }

        public Reservation_User_Event GetOneReservation(int reservationId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"reservation/{reservationId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Reservation_User_Event>(json)?.ToClient();
        }
    }
}
