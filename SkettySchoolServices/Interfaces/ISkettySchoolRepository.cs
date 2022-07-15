using SkettySchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchoolServices.Interfaces
{
    public interface ISkettySchoolRepository
    {
        // General 
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Teachers

        Task<TeacherModel> GetTeacherAsync(int teacherId);
        Task<List<TeacherModel>> GetAllTeachersAsync();

        //Pupils

        Task<PupilModel> GetPupilAsync(int pupilId);
        Task<List<PupilModel>> GetAllPupilsAsync();

        //Classes

        Task<ClassModel> GetClassAsync(int classId);
        Task<List<ClassModel>> GetAllClassesAsync();



    }
}
