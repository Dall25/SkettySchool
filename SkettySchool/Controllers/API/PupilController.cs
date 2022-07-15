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

    public class PupilController : ControllerBase
    {
        private readonly ISkettySchoolRepository _repository;
        private readonly IMapper _mapper;
        private readonly SkettySchoolContext _context;
        private readonly IPupilService _pupilService;


        public PupilController(ISkettySchoolRepository repository, IMapper mapper, SkettySchoolContext context, IPupilService pupilService)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _pupilService = pupilService;
        }

        [HttpGet("{pupilId}")]
        public async Task<ActionResult<PupilModel>> GetPupil(int pupilId)
        {
            try
            {
                var result = await _repository.GetPupilAsync(pupilId);

                if (result == null) return NotFound();
                //why are you doing a mapping here? take a look at the result type.
                return _mapper.Map<PupilModel>(result);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        // take a look at this method here. You want to be calling the service here like i am now rather than EF directly here. 
        [HttpGet]
        public async Task<ActionResult<List<PupilModel>>> Get()
        {
            try
            {
                var results = await _pupilService.GetAllPupils();

                return results;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PupilModel>> PostPupil(PupilModel model)
        {

            _context.Pupils.Add(model);

            await _context.SaveChangesAsync();

            return model;

        }

        [HttpDelete("{pupilID}")]
        public async Task<IActionResult> Delete(int pupilId)
        {
            try
            {
                var oldPupil = await _repository.GetPupilAsync(pupilId);
                if (oldPupil == null) return NotFound();

                _repository.Delete(oldPupil);

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
