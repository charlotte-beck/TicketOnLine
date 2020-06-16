using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Utils;
using Repositories;
using Repositories.Data;

namespace PresentationWeb_ASPCore.Controllers
{
    public class EventController : ControllerBase
    {
        private readonly IEventAPIRequester<Event> _eventRequester;
        private readonly ISessionManager _sessionManager;
        public EventController(IEventAPIRequester<Event> eventRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            _sessionManager = sessionManager;
            _eventRequester = eventRepository;
        }
        // GET: Event
        public ActionResult Index()
        {
            return View(_eventRequester.GetAllEvent().Where(e => e.EventDate >= DateTime.Now));
        }

        // GET: Event/Details/5
        public ActionResult Details(int eventId)
        {
            return View(_eventRequester.GetOneEvent(eventId));
        }

        #region Reste CRUD
        //// GET: Event/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Event/Create
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

        //// GET: Event/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Event/Edit/5
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

        //// GET: Event/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Event/Delete/5
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