using G = Global;
using Interfaces;
using Newtonsoft.Json;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Linq;
using Repositories.Data.Mappers;

namespace Repositories
{
    public class UserRepository : IUserAPIRequester<User>
    {
        private readonly HttpClient _httpClient;

        public UserRepository(string url)
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

        public void CreateUser(User entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PostAsync($"user/", content).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            G.User newUser = JsonConvert.DeserializeObject<G.User>(json);
            newUser.ToClient();
        }

        public void DeleteUser(int userId)
        {
            HttpResponseMessage responseMessage = _httpClient.DeleteAsync($"user/{userId}").Result;
            responseMessage.EnsureSuccessStatusCode();
        }

        public IEnumerable<User> GetAllUser()
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync("user/").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<G.User[]>(json).Select(ev => ev.ToClient());
        }

        public User GetOneUser(int userId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"user/{userId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.User>(json)?.ToClient();
        }

        public bool UpdateUser(int userId, User entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PutAsync($"user/{userId}", content).Result;
            return responseMessage.IsSuccessStatusCode;
        }

        public bool UpdateUserStatus(int userId, User entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PutAsync($"user/{userId}", content).Result;
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
