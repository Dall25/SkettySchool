using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Models
{
    public class PupilModel
    {
        [Key]
        public int PupilId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public DateTime DateOfBirth { get; set; }
       public int SchoolYear { get; set; }
       public string UserType { get; set; }

    }
}
