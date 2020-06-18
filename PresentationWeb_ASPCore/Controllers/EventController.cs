using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Models;
using PresentationWeb_ASPCore.Utils;
using PresentationWeb_ASPCore.Utils.CustomAttributes;
using Repositories;
using Repositories.Data;
using D = Repositories.Data;

namespace PresentationWeb_ASPCore.Controllers
{

    public class EventController : ControllerBase
    {
        private readonly IEventAPIRequester<D.Event> _eventRequester;
        private readonly ICommentAPIRequester<D.Comment, D.Comment_User_Event> _commentRequester;
        private readonly ISessionManager _sessionManager;
        public EventController(IEventAPIRequester<D.Event> eventRepository, ICommentAPIRequester<D.Comment, D.Comment_User_Event> commentRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            _sessionManager = sessionManager;
            _eventRequester = eventRepository;
            _commentRequester = commentRepository;
        }


        // GET: Event       
        public ActionResult Index()
        {
            //if (!(_sessionManager.user is null))
            //{
            //    return View(_eventRequester.GetAllEvent().Where(e => e.EventDate >= DateTime.Now));
            //}
            //else
            //{
            //    return View("Index", "Home");
            //}
            return View(_eventRequester.GetAllEvent().Where(e => e.EventDate >= DateTime.Now));
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            D.Event e = _eventRequester.GetOneEvent(id);
            EventComment ec = new EventComment
            {
                EventId = e.EventId,
                EventType = e.EventType,
                EventName = e.EventName,
                EventDescription = e.EventDescription,
                EventOrg = e.EventOrg,
                EventLocation = e.EventLocation,
                EventDate = e.EventDate,
                EventPrice = e.EventPrice,
                CommentList = _commentRequester.GetAllCommentByEvent(id).ToList()
    };

            return View(ec);
        }
        
        [AuthenticateRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(EventComment e)
        {

            if (!(SessionManager.user is null))
            {
                if (ModelState.IsValid)
                {
                    Comment comment = new Comment
                    {
                        UserId = _sessionManager.user.UserId,
                        EventId = e.EventId,
                        CommentDate = DateTime.Now,
                        CommentContent = e.CommentContent
                    };
                    _commentRequester.CreateComment(comment);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        #region Reservation
        //public ActionResult ToReservation(double eventPrice, int eventId, int nbTicket)
        //{
        //    return View(new D.Reservation()
        //    {
        //        UserId = SessionManager.user.UserId,
        //        EventId = eventId,
        //        NbTicket = nbTicket,
        //        FactureTotal = eventPrice*nbTicket,
        //        FactureDate = DateTime.Now
        //    });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ToReservation(Reservation reservation)
        //{

        //}
        #endregion

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