using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Repository.Services;
using Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentService _commentRepository;
        public CommentController()
        {
            _commentRepository = new CommentService();
        }

        // GET: api/Comment/user/5
        [HttpGet("user/{userId}", Name = "GetAllCommentByUser")]
        public IEnumerable<Comment_User_Event> GetCommentByUser(int userId)
        {
            return _commentRepository.GetAllCommentByUser(userId);
        }

        // GET: api/Comment/event/5
        [HttpGet("event/{eventId}", Name = "GetAllCommentByEvent")]
        public IEnumerable<Comment_User_Event> GetCommentByEvent(int eventId)
        {
            return _commentRepository.GetAllCommentByEvent(eventId);
        }

        // GET: api/Comment/5
        [HttpGet("{commentId}", Name = "GetOneComment")]
        public Comment_User_Event Get(int commentId)
        {
            return _commentRepository.GetOneComment(commentId);
        }

        // POST: api/Comment
        [HttpPost]
        public Comment Post([FromBody] Comment comment)
        {
            return _commentRepository.CreateComment(comment);
        }

        //// PUT: api/Comment/5
        //[HttpPut("{commentId}")]
        //public void Put(int commentId, [FromBody] Comment comment)
        //{
        //    _commentRepository.UpdateComment(commentId, comment);
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{commentId}")]
        public void Delete(int commentId)
        {
            _commentRepository.DeleteComment(commentId);
        }
    }
}
