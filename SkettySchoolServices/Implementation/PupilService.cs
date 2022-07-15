using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkettySchool.Models;
using SkettySchoolServices.Interfaces;

namespace SkettySchoolServices.Implementation
{
    public class PupilService : IPupilService
    {

        private readonly ISkettySchoolRepository _repository;
        public PupilService(ISkettySchoolRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<PupilModel>> GetAllPupils()
        {
           var pupilList = await _repository.GetAllPupilsAsync();

            return pupilList;
        }

        public async Task AddPupil(PupilModel pupilToAdd)
        {
            _repository.Add(pupilToAdd);
            await _repository.SaveChangesAsync();
        }

       


        //this service will be for anything pupil releated so you can contruct viewmodels etc to get hold of what you need. 
    }
}

