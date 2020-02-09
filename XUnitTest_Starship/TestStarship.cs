using Starship_Kneat.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest_Starship
{
    public class TestStarship
    {

        /// <summary>
        /// Test of function CalculateStops : Defined the Distance value "1000000" and Starship "Millennium Falcon"
        /// </summary>
        [Fact]
        public void CalculateStopsTest()
        {
            Util util = new Util();
            Starship starship = new Starship { Consumables = "2 months", MGLT = "75", Name = "Millennium Falcon" };

            var result = util.CalculateStops(1000000, starship);

            Assert.Equal(9, result);
        }
    }
}
