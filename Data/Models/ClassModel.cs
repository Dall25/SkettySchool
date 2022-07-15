using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Models
{
    public class ClassModel
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }

    }
}
