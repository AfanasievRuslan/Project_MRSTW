using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.BusinessLogic;
using FitPlaneLife.Domain.Enums;
using FitPlaneLife.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FitPlaneLife.Attributes
{
     public class AdminModeAttribute : ActionFilterAttribute
     {
          private readonly ISession _sessionBusinessLogic;
          public AdminModeAttribute()
          {
               var businessLogic = new BussinessLogic();
               _sessionBusinessLogic = businessLogic.GetSessionBL();
          }

          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                    if (profile != null && profile.Level == URole.Admin)
                    {
                         HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                         filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                    }
               }
          }
     }
}