﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Repository.Services;
using Global;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ASPCore.Controllers
{
    //[Authorize]
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
        //[AllowAnonymous]
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

        //POST: api/Event
        [HttpPost]
        public Event Post([FromBody] Event entity)
        {
            return _eventRepository.CreateEvent(entity);
        }

        //PUT: api/Event/5
        [HttpPut("{eventId}")]
        public void Put(int eventId, [FromBody] Event entity)
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
