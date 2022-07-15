using Microsoft.AspNetCore.Mvc;
using SkettySchoolServices.Interfaces;
using System.Threading.Tasks;

namespace SkettySchool.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;


        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        public async Task<ActionResult> Class()
        {
            var ClassModel = await _classService.GetAllClasses();

            return View(ClassModel);
        }


        public ActionResult Create()
        {
            return View();
        }
    }
}
