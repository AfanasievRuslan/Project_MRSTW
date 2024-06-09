using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitPlaneLife.Models
{
    public class Subscription
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime DateOfBirth { get; set; } 
    }
}