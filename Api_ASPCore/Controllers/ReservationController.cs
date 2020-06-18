﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_ASPCore.Repository.Services;
using Global;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ReservationService _reservationRepository;
        public ReservationController()
        {
            _reservationRepository = new ReservationService();
        }

        // GET: api/Reservation/user/5
        [HttpGet("user/{userId}", Name = "GetAllReservationByUser")]
        public IEnumerable<Reservation_User_Event> GetReservationByUser(int userId)
        {
            return _reservationRepository.GetAllReservationByUser(userId);
        }

        // GET: api/Reservation/event/5
        [HttpGet("event/{eventId}", Name = "GetAllReservationByEvent")]
        public IEnumerable<Reservation_User_Event> GetReservationByEvent(int eventId)
        {
            return _reservationRepository.GetAllReservationByEvent(eventId);
        }

        // GET: api/Reservation/5
        [HttpGet("{reservationid}", Name = "GetOneReservation")]
        public Reservation_User_Event Get(int reservationId)
        {
            return _reservationRepository.GetOneReservation(reservationId);
        }

        // POST: api/Reservation
        [HttpPost]
        public Reservation Post([FromBody] Reservation reservation)
        {
            return _reservationRepository.CreateReservation(reservation);
        }

        //// PUT: api/Reservation/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}