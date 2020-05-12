using Data;
using G = Global;
using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using Repositories.Mappers;

namespace Repositories
{
    public class EventRepository : IEventRepository<Event>
    {
        private readonly HttpClient _httpClient;
        public EventRepository(Uri uri)
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
            _httpClient.BaseAddress = uri;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<Event> GetAllEvent()
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync("event/getall/").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event[]>(json).Select(ev => ev.ToClient());
        }
        public Event GetOneEvent(int eventId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"event/{eventId}").Result;
            responseMessage.EnsureSuccessStatusCode();
            
            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event>(json)?.ToClient();
        }
        public IEnumerable<Event> GetAllByUser(int userId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"event/getbyuserid/{userId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event[]>(json).Select(ev => ev.ToClient());
        }

        public Event GetOneByUser(int userId, int eventId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"event/{userId}/{eventId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event>(json)?.ToClient();
        }
    }
}
