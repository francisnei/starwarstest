using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsTest.Models.Responses
{
    public class ShipsResponse
    {
        public string ShipName { get; set; }
        public int Recharges { get; set; }

        public static ShipsResponse Add(string name, int recharges)
        {
            return new ShipsResponse
            {
                ShipName = name,
                Recharges = recharges
            };
        }
    }
}
