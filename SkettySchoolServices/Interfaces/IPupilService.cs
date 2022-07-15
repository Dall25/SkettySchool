using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkettySchool.Models;

namespace SkettySchoolServices.Interfaces
{
    public interface IPupilService
    {
        Task<List<PupilModel>> GetAllPupils();

        Task AddPupil(PupilModel pupilToAdd);

    }
}

