using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starship_Kneat.Models
{
    public class Starship
    {

        public string Name { get; set; } //The name of this starship.The common name, such as "Death Star".
        public string Model { get; set; } //The model or official name of this starship.Such as "T-65 X-wing" or "DS-1 Orbital Battle Station".
        public string Manufacturer { get; set; } //The manufacturer of this starship.Comma separated if more than one.
        public string CostInCridits { get; set; } //The cost of this starship new, in galactic credits.
        public string Length { get; set; } //The length of this starship in meters.
        public string MaxAtmospheringSpeed { get; set; } //The maximum speed of this starship in the atmosphere. "N/A" if this starship is incapable of atmospheric flight.
        public string Crew { get; set; } //The number of personnel needed to run or pilot this starship.
        public string Passengers { get; set; } //The number of non-essential people this starship can transport.
        public string CargoCapacity { get; set; } //The maximum number of kilograms that this starship can transport.
        public string Consumables { get; set; } //The maximum length of time that this starship can provide consumables for its entire crew without having to resupply.
        public string HyperdriveRating { get; set; } //The class of this starships hyperdrive.
        public string MGLT { get; set; } //The Maximum number of Megalights this starship can travel in a standard hour.A "Megalight" is a standard unit of distance and has never been defined before within the Star Wars universe. This figure is only really useful for measuring the difference in speed of starships.We can assume it is similar to AU, the distance between our Sun (Sol) and Earth.
        public string StarshipClass { get; set; } //The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation"
        public string[] Pilots { get; set; } //An array of People URL Resources that this starship has been piloted by.
        public string[] Films { get; set; } //An array of Film URL Resources that this starship has appeared in.
        public string Created { get; set; } //the ISO 8601 date format of the time that this resource was created.
        public string Edited { get; set; } //the ISO 8601 date format of the time that this resource was edited.
        public string URL { get; set; } //the hypermedia URL of this resource.


        //ALL DESCRIPTIONS TAKEN FROM : https://swapi.co/documentation
    }
}
