using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Models;
using Api_ASPCore.Models.Data;
using Api_ASPCore.Repository.Services;
using Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userRepository;

        public UserController()
        {
            _userRepository = new UserService();
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAllUser();
        }

        // GET: api/User/5
        [HttpGet("{userId}", Name = "GetUser")]
        public User GetOne(int userId)
        {
            return _userRepository.GetOneUser(userId);
        }

        // POST: api/User
        [HttpPost]
        public User Post([FromBody] RegisterForm entity)
        {
            _userRepository.CreateUser(entity);
        }

        // PUT: api/User/5
        [HttpPut("{userId}")]
        public void Put(int userId, [FromBody] User entity)
        {
            _userRepository.UpdateUser(userId, entity);
        }

        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{userId}")]
        public void Delete(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
    }
}
