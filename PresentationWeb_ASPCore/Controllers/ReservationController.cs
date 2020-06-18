using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Models.Mappers;
using PresentationWeb_ASPCore.Utils;
using Repositories.Data;

namespace PresentationWeb_ASPCore.Controllers
{
    public class ReservationController : ControllerBase
    {
        private readonly IReservationAPIRequester<Reservation, Reservation_User_Event> _reservationRequester;
        private readonly ISessionManager _sessionManager;
        public ReservationController(IReservationAPIRequester<Reservation, Reservation_User_Event> reservationRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            _sessionManager = sessionManager;
            _reservationRequester = reservationRepository;
        }

        // GET: Reservation
        public ActionResult Index(int userId)
        {
            if (!(_sessionManager.user is null))
            {
                userId = _sessionManager.user.UserId;
                return View(_reservationRequester.GetAllReservationByUser(userId));
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int reservationId)
        {
            return View(_reservationRequester.GetOneReservation(reservationId).ToWeb());
        }

        #region Reste CRUD
        //// GET: Reservation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Reservation/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Reservation/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Reservation/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Reservation/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Reservation/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion
    }
}