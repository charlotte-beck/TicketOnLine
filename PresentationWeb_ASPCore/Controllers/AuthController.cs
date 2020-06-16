using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Models.Mappers;
using PresentationWeb_ASPCore.Utils;
using Repositories.Data;
using Repositories.Data.Forms;

namespace PresentationWeb_ASPCore.Controllers
{
    //[Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAPIRequester<RegisterForm, LoginForm, User> _authAPIRequester;
        private readonly ISessionManager _sessionManager;
        public AuthController(IAuthAPIRequester<RegisterForm, LoginForm, User> authRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            _authAPIRequester = authRepository;
            _sessionManager = sessionManager;
        }

        // GET: Auth
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("Login","Auth");
        }

        // GET: Auth/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Auth/Create
        //[AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Auth/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterForm registerForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here

                    _authAPIRequester.Register(registerForm);
                    return RedirectToAction("Login","Auth");
                }
                catch
                {
                    return View("Error");
                }
            }
            return View(registerForm.ToASP());
            
        }
        //[AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        //[AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginForm loginForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User u = _authAPIRequester.Login(loginForm);
                    if (!(u is null))
                    {
                        _sessionManager.user = u;
                        return RedirectToAction("Index", "Event");
                    }

                    ViewBag.Message = "Incorrect login or password!";
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            return View(loginForm);
        }

        public IActionResult Logout()
        {
            _sessionManager.Logout();
            return RedirectToAction("Login","Auth");
        }

        #region Reste CRUD
        // GET: Auth/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}