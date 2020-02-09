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
            //Get in all starships
            List<Starship> starships = ApiREST.GetStarship();

            List<StarshipStop> listResult = createListResult(txtMGLT, starships);
                        
            return View("Index", listResult);
        }


        /// <summary>
        /// Creating List with Starship stops
        /// </summary>
        /// <param name="MGLTView"></param>
        /// <param name="listStarship"></param>
        /// <param name="listResult"></param>
        /// <returns></returns>
        public List<StarshipStop> createListResult(string MGLTView, List<Starship> listStarship)
        {
            List<StarshipStop> listResult = new List<StarshipStop>();

            foreach (var item in listStarship)
            {
                string consumables = item.Consumables;
                int stops = 0;
                string[] consumablesSplit = consumables.Split(' ');

                int number = Convert.ToInt32(consumablesSplit[0]);
                string strTime = consumablesSplit[1];
                int consumablesDays = util.getDays(strTime);

                stops = Convert.ToInt32(Convert.ToInt32(MGLTView) / (number * consumablesDays * 24 * Convert.ToInt32(item.MGLT)));

                if (stops >= 0)
                    listResult.Add(new StarshipStop() { StarshipName = item.Name, Stops = stops });
            }

            return listResult;
        }
    }
}
