﻿using FitPlaneLife.BusinessLogic.DBModel;
using FitPlaneLife.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPlaneLife.BusinessLogic
{
     public class BussinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
          
     }
}
