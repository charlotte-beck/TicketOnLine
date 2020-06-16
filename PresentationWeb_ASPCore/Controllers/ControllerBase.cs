using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Utils;

namespace PresentationWeb_ASPCore.Controllers
{
    public class ControllerBase : Controller
    {
        protected internal ISessionManager SessionManager { get; private set; }
        public ControllerBase(ISessionManager sessionManager)
        {
            SessionManager = sessionManager;
        }
    }
}