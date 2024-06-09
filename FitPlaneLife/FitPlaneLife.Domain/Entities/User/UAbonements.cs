using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPlaneLife.Domain.Entities.User
{
     public class UAbonements
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          public string Name { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public DateTime DateOfBirth { get; set; }
          public string Type { get; set; }
          public decimal Price { get; set; }
          public int Duration { get; set; }
     }
}
