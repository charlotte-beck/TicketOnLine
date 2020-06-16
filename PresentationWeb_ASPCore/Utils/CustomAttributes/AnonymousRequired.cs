using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationWeb_ASPCore.Utils.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AnonymousRequired : TypeFilterAttribute
    {
        public AnonymousRequired() : base(typeof(AnonymousRequiredFilter))
        {

        }

        private class AnonymousRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

                if (!(sessionManager.user is null))
                {
                    context.Result = new RedirectToActionResult("Index", "Event", null);
                }
            }
        }
    }
}
