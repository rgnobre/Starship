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
    }
}
