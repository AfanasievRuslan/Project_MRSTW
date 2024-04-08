using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FitPlaneLife.Domain.Entities.User;
namespace FitPlaneLife.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
        public UserContext():
            base("name=FitPlaneLife")
        {
        }
          public virtual DbSet<UserTable> Users { get; set; }
     }
}
