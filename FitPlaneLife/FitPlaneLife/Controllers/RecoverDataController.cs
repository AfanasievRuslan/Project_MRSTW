using AutoMapper;
using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.Domain.Entities.User;
using FitPlaneLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitPlaneLife.Controllers
{
    public class RecoverDataController : Controller
    {
          private readonly ISession _session;
          public ActionResult RecoverData()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult RecoverData(RecoverPasswordData data)
          {
               if (ModelState.IsValid)
               {
                    var user = Mapper.Map<UCheckData>(data);
                    var checkUser = _session.CheckUser(user);
                    if (checkUser.Status)
                    {
                         TempData["email"] = user.Email;
                         return RedirectToAction("Recover", "RecoverData");
                    }
                    else
                    {
                         ModelState.AddModelError("", checkUser.StatusMsg);
                         return View();
                    }
               }
               return View();
          }
          public ActionResult Recover()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Recover(RecoverPasswordData data)
          {
               string email = (string)TempData["email"];
               if (ModelState.IsValid)
               {
                    var user = Mapper.Map<UCheckData>(data);
                    var changePassword = _session.RecoverPassword(email, user.Password);
                    if (changePassword)
                    {
                         return RedirectToAction("Login", "Login");
                    }
               }
               return View();
          }
     }
}