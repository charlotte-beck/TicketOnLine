using Interfaces;
using Newtonsoft.Json;
using Repositories.Data;
using Repositories.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using G = Global;

namespace Repositories.APIRequester
{
    public class CommentRequester : ICommentAPIRequester<Comment, Comment_User_Event>
    {
        private readonly HttpClient _httpClient;
        public CommentRequester(string url)
        {
            //var handler = new HttpClientHandler
            //{
            //    SslProtocols = SslProtocols.Default
            //};

            //handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
            //{
            //    return true;
            //};

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Comment CreateComment(Comment entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity.ToGlobal()));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = _httpClient.PostAsync("comment", content).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Comment>(json).ToClient();
        }

        public IEnumerable<Comment_User_Event> GetAllCommentByEvent(int eventId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"comment/event/{eventId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<G.Comment_User_Event[]>(json).Select(ev => ev.ToClient());
        }

        public IEnumerable<Comment_User_Event> GetAllCommentByUser(int userId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"comment/user/{userId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<G.Comment_User_Event[]>(json).Select(ev => ev.ToClient());
        }

        public Comment_User_Event GetOneComment(int commentId)
        {
            HttpResponseMessage responseMessage = _httpClient.GetAsync($"comment/{commentId}").Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Comment_User_Event>(json)?.ToClient();
        }

        //public bool UpdateComment(int commentId, Comment entity)
        //{
        //    HttpContent content = new StringContent(JsonConvert.SerializeObject(entity.ToGlobal()));
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    HttpResponseMessage responseMessage = _httpClient.PutAsync($"comment/{commentId}", content).Result;
        //    return responseMessage.IsSuccessStatusCode;
        //}

        public void DeleteComment(int commentId)
        {
            HttpResponseMessage responseMessage = _httpClient.DeleteAsync($"comment/{commentId}").Result;
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
