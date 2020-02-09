using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Starship_Kneat.Models
{
    public class ApiREST
    {               

        /// <summary>
        /// HttpGet Starship in Swapi API 
        /// </summary>
        /// <returns></returns>
       public static List<Starship> GetStarship()
        {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://swapi.co/api/starships");
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            List<Starship> starshipList = new List<Starship>();
                       
            var listStarship = JObject.Parse(response.Content.ReadAsStringAsync().Result)["results"];
            
            foreach (var starship in listStarship)
            {
                starshipList.Add(new Starship()
                {
                    Name = starship["name"].ToString(),
                    Model = starship["model"].ToString(),
                    Manufacturer = starship["manufacturer"].ToString(),
                    CostInCridits = starship["cost_in_credits"].ToString(),
                    Length = starship["length"].ToString(),
                    MaxAtmospheringSpeed = starship["max_atmosphering_speed"].ToString(),
                    Crew = starship["crew"].ToString(),
                    Passengers = starship["passengers"].ToString(),
                    CargoCapacity = starship["cargo_capacity"].ToString(),
                    Consumables = starship["consumables"].ToString(),
                    HyperdriveRating = starship["hyperdrive_rating"].ToString(),
                    MGLT = starship["MGLT"].ToString(),
                    StarshipClass = starship["starship_class"].ToString(),
                    Pilots = JsonConvert.DeserializeObject<string[]>(starship["pilots"].ToString()),
                    Films = JsonConvert.DeserializeObject<string[]>(starship["films"].ToString()),
                    Created = starship["created"].ToString(),
                    Edited = starship["edited"].ToString(),
                    URL = starship["url"].ToString()
                });
            }

            return starshipList;
        }
    }
}
