using SkettySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkettySchoolServices.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassModel>> GetAllClasses();
    }
}
