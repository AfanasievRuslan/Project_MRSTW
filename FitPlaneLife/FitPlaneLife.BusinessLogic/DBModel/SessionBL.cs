using FitPlaneLife.BusinessLogic.Core;
using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FitPlaneLife.BusinessLogic.DBModel
{
     public class SessionBL : UserApi, ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }

          public URegisterResp UserRegister(URegisterData data)
          {
               return UserRegisterAction(data);
          }

          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }
          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
