using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Starship_Kneat.Models;


namespace Starship_Kneat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Util util = new Util();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Calculate(string txtMGLT)
        {
            //Get all starships
            List<Starship> starships = ApiREST.GetStarship();

            List<StarshipStop> listResult = util.CreateListResult(txtMGLT, starships);

            return View("Index", listResult);
        }


       
    }
}
