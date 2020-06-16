using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb_ASPCore.Utils;
using PresentationWeb_ASPCore.Utils.CustomAttributes;

namespace PresentationWeb_ASPCore.Controllers
{
    [IsLogged]
    public class ControllerBase : Controller
    {
        protected internal ISessionManager SessionManager { get; private set; }
        public ControllerBase(ISessionManager sessionManager)
        {
            SessionManager = sessionManager;
        }
    }
}