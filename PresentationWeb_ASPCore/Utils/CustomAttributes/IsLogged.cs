using Microsoft.AspNetCore.Mvc.Filters;
using PresentationWeb_ASPCore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb_ASPCore.Utils.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class IsLogged : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerBase controller = (ControllerBase)context.Controller;
            controller.ViewBag.IsLogged = !(controller.SessionManager.user is null);
        }
    }
}
