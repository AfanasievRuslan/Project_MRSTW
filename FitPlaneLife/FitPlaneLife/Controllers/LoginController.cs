using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitPlaneLife.Models;
using AutoMapper;
using FitPlaneLife.Domain.Entities.User;

namespace FitPlaneLife.Controllers
{
    public class LoginController : Controller
    {
        // GET: LogIn
        public ActionResult Login()
        {
            return View();
        }
          private readonly ISession _session;
          public LoginController()
          {

               var bl = new BussinessLogic();
               _session = bl.GetSessionBL();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult LogIn(UserLogin login)
          {
               if (ModelState.IsValid)
               {
                    var data = Mapper.Map<ULoginData>(login);

                    data.LoginIp = Request.UserHostAddress;
                    data.LoginDateTime = DateTime.Now;

                    var userLogin = _session.UserLogin(data);
                    if (userLogin.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(login.Email);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }
               }
               return View();
          }
     }
}