using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SkettySchool.Models;
using SkettySchoolServices.Interfaces;
using SkettySchoolServices.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkettySchoolServices.Implementation
{
    public class TeacherService : ITeacherService
    {

        private readonly ISkettySchoolRepository _repository;
        private readonly IValidator<TeacherModel> _validator;                                         


        public TeacherService(ISkettySchoolRepository repository, IValidator<TeacherModel> validator)
        {
            _repository = repository;
            _validator = validator;
            
            

        }


        public async Task<List<TeacherModel>> GetAllTeachers()
        {
            var teacherList = await _repository.GetAllTeachersAsync();

            return teacherList;
        }

         public async Task AddTeacher(TeacherModel teacherToAdd)
         {
            

            _repository.Add(teacherToAdd);
            await _repository.SaveChangesAsync();

         } 


        

        

    } 

            
       


       
}
