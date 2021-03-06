﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Ministop.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sess = Session["DangNhap"];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}