using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationWeb_ASPCore.Models;
using PresentationWeb_ASPCore.Utils;
using PresentationWeb_ASPCore.Utils.CustomAttributes;

namespace PresentationWeb_ASPCore.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly ISessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, ISessionManager sessionManager) : base(sessionManager)
        {
            _logger = logger;
            //_sessionManager = sessionManager;
        }

        //[AnonymousRequired]
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
