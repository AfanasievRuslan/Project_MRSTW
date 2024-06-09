using FitPlaneLife.BusinessLogic.Core;
using FitPlaneLife.BusinessLogic.Interfaces;
using FitPlaneLife.Domain.Entities.Admin;
using FitPlaneLife.Domain.Entities.User;
using System;
using System.Collections.Generic;
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
          public BoolResp AddAbonament(AbonamentData data)
          {
               return AddAbonamentAction(data);
          }

          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }

          public BoolResp CheckUser(UCheckData data) 
          {
               return CheckUserAction(data);
          }

          public bool RecoverPassword(string email, string password)
          {
               return RecoverPasswordAction(email, password);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
