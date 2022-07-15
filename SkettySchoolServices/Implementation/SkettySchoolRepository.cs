using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkettySchool.Models;
using SkettySchoolServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Data
{
    public class SkettySchoolRepository : ISkettySchoolRepository
  {

    private readonly SkettySchoolContext _context;
    private readonly ILogger<SkettySchoolRepository> _logger;

    public SkettySchoolRepository(SkettySchoolContext context, ILogger<SkettySchoolRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public void Add<T>(T entity) where T : class
    {
        _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
        _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        _logger.LogInformation($"Attempitng to save the changes in the context");

        // Only return success if at least one row was changed
        return (await _context.SaveChangesAsync()) > 0;
    }



    //Teachers
    public async Task<TeacherModel> GetTeacherAsync(int teacherId)
    {
        _logger.LogInformation($"Getting Teacher");

        var query = _context.Teachers
          .Where(t => t.TeacherId == teacherId);

        return await query.FirstOrDefaultAsync();
    }

        public async Task<List<TeacherModel>> GetAllTeachersAsync()
        {
            _logger.LogInformation($"Getting All Teachers");

            var query = _context.Teachers
              .OrderBy(t => t.TeacherId);

            return await query.ToListAsync();
        }

        //Pupils

        public async Task<PupilModel> GetPupilAsync(int pupilId)
        {
            _logger.LogInformation($"Getting Pupil");

            var query = _context.Pupils
              .Where(t => t.PupilId == pupilId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<PupilModel>> GetAllPupilsAsync()
        {
            _logger.LogInformation($"Getting All Pupils");

            var query = _context.Pupils
              .OrderBy(t => t.PupilId);

            return await query.ToListAsync();
        }

        //Classes

        public async Task<ClassModel> GetClassAsync(int classId)
        {
            _logger.LogInformation($"Getting Class");

            var query = _context.Classes
              .Where(t => t.ClassId == classId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<ClassModel>> GetAllClassesAsync()
        {
            _logger.LogInformation($"Getting All Classes");

            var query = _context.Classes
              .OrderBy(t => t.ClassId);

            return await query.ToListAsync();
        }


    }
}
