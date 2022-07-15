using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public class ClassController : ControllerBase
        {
            private readonly ISkettySchoolRepository _repository;
            private readonly IMapper _mapper;
            private readonly SkettySchoolContext _context;


            public ClassController(ISkettySchoolRepository repository, IMapper mapper, SkettySchoolContext context)
            {
                _repository = repository;
                _mapper = mapper;
                _context = context;



            }

            [HttpGet("{ClassId}")]
            public async Task<ActionResult<ClassModel>> GetClass(int classId)
            {
                try
                {
                    var result = await _repository.GetClassAsync(classId);

                    if (result == null) return NotFound();

                    return _mapper.Map<ClassModel>(result);

                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
                }
            }

            [HttpGet]
            public async Task<ActionResult<ClassModel[]>> Get()
            {
                try
                {
                    var results = await _repository.GetAllClassesAsync();

                    return _mapper.Map<ClassModel[]>(results);
                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
                }
            }

            [HttpPost]
            public async Task<ActionResult<ClassModel>> PostClass(ClassModel model)
            {

                _context.Classes.Add(model);

                await _context.SaveChangesAsync();

                return model;

            }

            [HttpDelete("{ClassID}")]
            public async Task<IActionResult> Delete(int classId)
            {
                try
                {
                    var oldClass = await _repository.GetClassAsync(classId);
                    if (oldClass == null) return NotFound();

                    _repository.Delete(oldClass);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Ok();
                    }

                }
                catch (Exception)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
                }

                return BadRequest("Failed to delete Class");
            }
        }
    }

