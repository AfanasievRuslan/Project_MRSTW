using FitPlaneLife.Domain.Entities.Admin;
using FitPlaneLife.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FitPlaneLife.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
          URegisterResp UserRegister(URegisterData data);
          HttpCookie GenCookie(string loginCredential);
          bool RecoverPassword(string email, string password);
          UserMinimal GetUserByCookie(string apiCookieValue);
          BoolResp CheckUser(UCheckData data);
     }
}
