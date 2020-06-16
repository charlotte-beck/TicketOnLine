using Interfaces;
using Newtonsoft.Json;
using Repositories.Data;
using Repositories.Data.Forms;
using Repositories.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace Repositories
{
    public class AuthRepository : IAuthAPIRequester<RegisterForm, LoginForm, User>
    {
        private readonly HttpClient _httpClient;
        private UserRepository _userRepository;

        public AuthRepository(string url)
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
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }



        public User Login(LoginForm loginForm)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(loginForm));
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PostAsync("auth/login", content).Result;
            responseMessage.EnsureSuccessStatusCode();

            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                return null;

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(json);
        }

        public void Register(RegisterForm registerForm)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(registerForm));
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PostAsync("auth/register", content).Result;
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
