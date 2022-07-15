using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkettySchool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SkettySchool.Controllers
{
    public class HomeController : Controller
    {
        //GET: /<controller>/
        public ActionResult Index()
        {
          return View();
       }
    }
}
