using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.BusinessLogic;
using FitPlaneLife.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
     public class BaseController : Controller
     {
          private readonly ISession _session;

          public BaseController()
          {
               var bl = new BussinessLogic();
               _session = bl.GetSessionBL();
          }

          public void RemoveExpiredSessions()
          {
               using (var db = new SessionContext())
               {
                    var expiredSessions = db.Sessions.Where(s => s.ExpireTime < DateTime.Now).ToList();
                    if (expiredSessions.Any())
                    {
                         foreach (var session in expiredSessions)
                         {
                              db.Sessions.Remove(session);
                         }
                         db.SaveChanges();
                    }
               }
          }
          public void SessionStatus()
          {
               var apiCookie = Request.Cookies["X-KEY"];
               if (apiCookie != null)
               {
                    var profile = _session.GetUserByCookie(apiCookie.Value);
                    if (profile != null)
                    {
                         System.Web.HttpContext.Current.SetMySessionObject(profile);
                         System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                         System.Web.HttpContext.Current.Session["Email"] = profile.Email;
                    }
                    else
                    {
                         System.Web.HttpContext.Current.Session.Clear();
                         if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                         {
                              var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                              if (cookie != null)
                              {
                                   cookie.Expires = DateTime.Now.AddDays(-1);
                                   ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                              }
                         }
                         System.Web.HttpContext.Current.Session["LoginStatus"] = "guest";
                         RemoveExpiredSessions();
                    }
               }
               else
               {
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "guest";
                    RemoveExpiredSessions();
               }
          }
     }
}