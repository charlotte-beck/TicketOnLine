using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Models;
using Api_ASPCore.Repository.Services;
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
        private EventService _eventRepository;

        public EventController()
        {
            _eventRepository = new EventService();
        }

        // GET: api/Event
        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return _eventRepository.GetAllEvent();
        }

        // GET: api/Event/5
        [HttpGet("{eventId}", Name = "GetEvent")]
        public Event GetOne(int eventId)
        {
            return _eventRepository.GetOneEvent(eventId);
        }

        //// GET: api/EventUser
        //[Route("api/Event/{userId:int}")]
        //[HttpGet]
        //public IEnumerable<Event> GetAllByUserId(int userId)
        //{
        //    throw new NotImplementedException();
        //}

        //// GET: api/EventUser/5
        //[Route("api/Todo/{userId:int}/{eventId:int}")]
        //[HttpGet("{eventId}", Name = "Get"),HttpGet("{userId}", Name = "Get")]
        //public Event GetOneByUserId(int eventId, int userId)
        //{
        //    throw new NotImplementedException();
        //}

        //POST: api/Event
        [HttpPost]
        public Event Post([FromBody] CreateEvent entity)
        {
            _eventRepository.CreateEvent(entity);
        }

        //PUT: api/Event/5
        [HttpPut("{eventId}")]
        public void Put(int eventId, [FromBody] UpdateEvent entity)
        {
            _eventRepository.UpdateEvent(eventId, entity);
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{eventId}")]
        public void Delete(int eventId)
        {
            _eventRepository.DeleteEvent(eventId);
        }
    }
}
