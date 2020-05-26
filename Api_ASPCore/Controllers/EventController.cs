using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Models.Mappers;
using Api_ASPCore.Repository.Services;

using Api_ASPCore.Models.Data;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.GlobalRepositories;

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
        [HttpGet("{eventId}", Name = "Get")]
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
        public void Post([FromBody] Event entity)
        {
            _eventRepository.CreateEvent(entity);
        }

        //PUT: api/Event/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int eventId)
        {
            _eventRepository.DeleteEvent(eventId);
        }
    }
}
