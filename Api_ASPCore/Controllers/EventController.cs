using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventRepository<Event> _eventRepository;

        public EventController()
        {
            _eventRepository = new EventRepository();
        }

        // GET: api/Event
        [Route("api/Event/GetAllEvent")]
        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAllEvent();
        }

        // GET: api/Event/5
        [Route("api/Event/{eventId:int}")]
        [HttpGet("{eventId}", Name = "Get")]
        public Event GetOne(int eventId)
        {
            return _eventRepository.GetOneEvent(eventId);
        }

        // GET: api/EventUser
        [Route("api/Event/GetAllByUserId/{userId:int}")]
        [HttpGet]
        public IEnumerable<Event> GetAllByUserId(int userId)
        {
            return _eventRepository.GetAllByUser(userId);
        }

        // GET: api/EventUser/5
        [Route("api/Todo/{userId:int}/{eventId:int}")]
        [HttpGet("{eventId}", Name = "Get"),HttpGet("{userId}", Name = "Get")]
        public Event GetOneByUserId(int eventId, int userId)
        {
            return _eventRepository.GetOneByUser(eventId, userId);
        }

        // POST: api/Event
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT: api/Event/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
