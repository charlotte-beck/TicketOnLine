using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Models;
using PresentationWeb_ASPCore.Models.Mappers;
using PresentationWeb_ASPCore.Utils;
using PresentationWeb_ASPCore.Utils.CustomAttributes;
using Repositories.Data;
using D = Repositories.Data;

namespace PresentationWeb_ASPCore.Controllers
{
    [AuthenticateRequired]
    public class UserController : ControllerBase
    {
        private readonly IUserAPIRequester<D.User> _userRequester;
        private readonly ISessionManager _sessionManager;

        public UserController(IUserAPIRequester<D.User> userRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            _userRequester = userRepository;
            _sessionManager = sessionManager;
        }

        // GET: User/Details/5
        public ActionResult Details(int userId)
        {
            userId = _sessionManager.user.UserId;
            return View(_userRequester.GetOneUser(userId).ToWeb());
        }
        
        // GET: User/Edit/5
        public ActionResult Edit(int userId)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int userId, UpdateUserForm updateUserForm)
        {
            //D.User user = _sessionManager.user;
            userId = _sessionManager.user.UserId;
            try
            {
                // TODO: Add update logic here
                _userRequester.UpdateUser(userId, new D.User(userId, updateUserForm.FirstName, updateUserForm.LastName, updateUserForm.Email, updateUserForm.Passwd, _sessionManager.user.IsActive, _sessionManager.user.IsAdmin, _sessionManager.user.Token));
                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View("Error");
            }
        }

        //// GET: User/Delete/5
        //public ActionResult Delete(int userId)
        //{
        //    return View();
        //}

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int userId)
        {
            userId = _sessionManager.user.UserId;
            try
            {
                // TODO: Add delete logic here
                _userRequester.DeleteUser(userId);
                return RedirectToAction("Register", "Auth");
            }
            catch
            {
                return View("Error");
            }
        }

        #region Reste CRUD
        //// GET: User
        //public ActionResult Index()
        //{

        //    return View(_userRequester.GetOneUser(_sessionManager.user.UserId));
        //}

        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/Create
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
        #endregion
    }
}