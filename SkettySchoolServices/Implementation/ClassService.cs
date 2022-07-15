using SkettySchool.Models;
using SkettySchoolServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkettySchoolServices.Implementation
{
    public class ClassService : IClassService
    {
        private readonly ISkettySchoolRepository _repository;
        public ClassService(ISkettySchoolRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClassModel>> GetAllClasses()
        {
            var classList = await _repository.GetAllClassesAsync();

            return classList;
        }
    }
}
