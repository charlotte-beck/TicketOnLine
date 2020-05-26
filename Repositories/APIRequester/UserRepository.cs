using Global;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;

namespace Repositories
{
    public class UserRepository : IUserRepository<User>
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
        public void DeleteUser(int userId)
        {
            HttpResponseMessage responseMessage = _httpClient.DeleteAsync($"user/{userId}").Result;
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
