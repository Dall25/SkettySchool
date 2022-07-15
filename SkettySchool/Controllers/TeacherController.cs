using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SkettySchool.Models;
using SkettySchoolServices.Interfaces;
using SkettySchoolServices.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly TeacherValidator _validator;



        public TeacherController(ITeacherService teacherService, TeacherValidator validator)
        {
            _teacherService = teacherService;
            _validator = validator;
        }

        public async Task<ActionResult> Teacher()
        {
            var TeacherModel = await _teacherService.GetAllTeachers();

            return View(TeacherModel);
        }

        //Get
        public async Task<ActionResult> AddTeacher()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddTeacher(TeacherModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("AddTeacher", model);

            }
            
            await _teacherService.AddTeacher(model);

            TempData["notice"] = "Person successfully created";
            return RedirectToAction("Teacher");
        }

    }
}

