using CollegeAdministration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CollegeAdministration.Providers
{
    public class CustomAuthorization : AuthorizeAttribute
    {
        public CustomAuthorization()
        {
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Unauthorized", action = "Index" }));
                //throw new Exception("Unauthorised");
            }
            else
            {
                CustomPrincipal p = HttpContext.Current.User as CustomPrincipal;
                if (!p.HasControllerPermission(ctrlName))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Unauthorized", action = "Index" }));
                }
            }
        }
    }
}