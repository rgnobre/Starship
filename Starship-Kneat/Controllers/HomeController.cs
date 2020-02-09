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

            List<StarshipStop> listResult = CreateListResult(txtMGLT, starships);

            return View("Index", listResult);
        }


        /// <summary>
        /// Creating List with Starship stops
        /// </summary>
        /// <param name="MGLTInput">MGLT informed in View</param>
        /// <param name="listStarship"></param>
        /// <returns>Starship List</returns>
        public List<StarshipStop> CreateListResult(string MGLTInput, List<Starship> listStarship)
        {
            List<StarshipStop> listResult = new List<StarshipStop>();

            foreach (var item in listStarship)
            {
                int stops = 0;

                stops = util.CalculateStops(Convert.ToInt32(MGLTInput), item);

                if (stops >= 0)
                    listResult.Add(new StarshipStop() { StarshipName = item.Name, Stops = stops });
            }

            return listResult;
        }
    }
}
