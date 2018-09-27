using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeAdministration.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(ex, filterContext.RouteData.Values["controller"].ToString(),
       filterContext.RouteData.Values["action"].ToString());
            filterContext.Result = new ViewResult()
            {
                 ViewName="Unauthorized",
                 ViewData=new ViewDataDictionary(model)
                  
            };
        }
    }
}