using Microsoft.AspNetCore.Mvc;
using SkettySchool.Models;
using SkettySchoolServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Controllers
{
    public class PupilController : Controller
    {
        private readonly IPupilService _pupilService;
       

        public PupilController(IPupilService pupilService)
        {
            _pupilService = pupilService;
        }

        public async Task<ActionResult> Pupil()
        {
            var PupilModel = await _pupilService.GetAllPupils();

            return View(PupilModel);
        }

        //Get
        public async Task<ActionResult> AddPupil()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddPupil(PupilModel model)
        {
            await _pupilService.AddPupil(model);

            return RedirectToAction("Pupil");
        }

    }
}

