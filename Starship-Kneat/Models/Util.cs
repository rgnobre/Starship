using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starship_Kneat.Models
{
    public class Util
    {
        public int getDays(string strtime)
        {
            int result = 0;

            switch (strtime.Replace('s', ' ').Trim())
            {
                case "year":
                    result = 365;
                    break;

                case "month":
                    result = 30;
                    break;

                case "week":
                    result = 7;
                    break;

                case "day":
                    result = 1;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Calculate the stops number of a starship
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public int CalculateStops(int distance, Starship item)
        {
            string consumables = item.Consumables;
            string[] consumablesSplit = consumables.Split(' ');

            int number = Convert.ToInt32(consumablesSplit[0]);
            string strTime = consumablesSplit[1];

            //Identifies the unit of days(years, months, weeks or days) and get the correct numbers of days. 
            int consumablesDays = getDays(strTime);

            //Considering that the MGLT is per hour, multiplied by the total number of days that can 
            //supply consumables for the entire crew without the need for refueling and multiplied by 24 hours (1 day).
            int totalHours = (number * consumablesDays * 24);

            
            return Convert.ToInt32(Convert.ToInt32(distance) / (totalHours * Convert.ToInt32(item.MGLT)));
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
                var stops = CalculateStops(Convert.ToInt32(MGLTInput), item);

                if (stops >= 0)
                    listResult.Add(new StarshipStop() { StarshipName = item.Name, Stops = stops });
            }

            return listResult;
        }
    }
}
