using AutoMapper;
using FitPlaneLife.App_Start;
using FitPlaneLife.Domain.Entities.User;
using FitPlaneLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FitPlaneLife
{
    public class Global : HttpApplication
    {
          void Application_Start(object sender, EventArgs e)
          {
               // Code that runs on application startup
               AreaRegistration.RegisterAllAreas();
               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
               InitializeAutoMapper();
          }

          protected static void InitializeAutoMapper()
          {
               Mapper.Initialize(cfg =>
               {
                    cfg.CreateMap<UserLogin, ULoginData>();
                    cfg.CreateMap<UserRegister, URegisterData>();
                    cfg.CreateMap<Subscription, AbonamentData>();
                    cfg.CreateMap<UserTable, UserMinimal>();
               });
          }
     }
}