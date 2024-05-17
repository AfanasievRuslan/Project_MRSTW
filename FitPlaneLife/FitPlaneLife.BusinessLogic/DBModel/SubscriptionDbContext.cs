using FitPlaneLife.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPlaneLife.BusinessLogic.DBModel
{
    public class SubscriptionDbContext : DbContext
    {
        public SubscriptionDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
