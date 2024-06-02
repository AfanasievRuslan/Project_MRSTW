using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FitPlaneLife.Domain.Entities.User;
using FitPlaneLife.Models;

namespace FitPlaneLife.Controllers
{
    public class RegisterController : Controller
    {
          // GET: Register
          private readonly ISession _session;
          public RegisterController()
          {
               var bl = new BussinessLogic();
               _session = bl.GetSessionBL();
          }
          public ActionResult Register()
          {
            return View();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Register(UserRegister register)
          {
               if (ModelState.IsValid)
               {
                    var data = Mapper.Map<URegisterData>(register);

                    data.LoginIp = Request.UserHostAddress;
                    data.LoginDateTime = DateTime.Now;

                    var userRegister = _session.UserRegister(data);
                    if (userRegister.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(register.Email);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", userRegister.StatusMsg);
                         return View();
                    }
               }
               return View();
          }

     }
}