using SkettySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkettySchoolServices.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherModel>> GetAllTeachers();

        Task AddTeacher(TeacherModel teacherToAdd);
    }
}
