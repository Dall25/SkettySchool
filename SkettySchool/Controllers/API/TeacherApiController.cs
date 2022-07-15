using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SkettySchool.Data;
using SkettySchool.Models;
using SkettySchoolServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Controllers.API
{


    [Route("api/[controller]")]
    [ApiController]
    public class TeacherApiController : ControllerBase
    {
        private readonly ISkettySchoolRepository _repository;
        private readonly IMapper _mapper;
        private readonly SkettySchoolContext _context;
        private readonly ITeacherService _teacherService;


        public TeacherApiController(ISkettySchoolRepository repository, IMapper mapper, SkettySchoolContext context, ITeacherService teacherService)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _teacherService = teacherService;
        }



        [HttpGet("{teacherId}")]
        public async Task<ActionResult<TeacherModel>> Get(int teacherId)
        {
            try
            {
                var result = await _repository.GetTeacherAsync(teacherId);

                if (result == null) return NotFound();

                return _mapper.Map<TeacherModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherModel>>> Get()
        {
            try
            {
                var results = await _teacherService.GetAllTeachers();

                return results;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // public async Task<ActionResult<TeacherModel>> Post([FromBody]TeacherModel model)
        // {
        //  _context.Teachers.Add(model);
        //  _context.SaveChanges();
        //  return model;

        // }

        [HttpPost]
        public async Task<ActionResult<TeacherModel>> Create(TeacherModel model)

        {

            _context.Teachers.Add(model);

            await _context.SaveChangesAsync();

            return model;

        }

        [HttpDelete("{teacherID}")]
        public async Task<IActionResult> Delete(int teacherId)
        {
            try
            {
                var oldTeacher = await _repository.GetTeacherAsync(teacherId);
                if (oldTeacher == null) return NotFound();

                _repository.Delete(oldTeacher);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete Pupil");
        }

     


    }
}


