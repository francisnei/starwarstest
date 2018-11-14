using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsTest.Models.Results
{
    public class StarShipsResult
    {
        [JsonProperty("count")]
        public int CountItems { get; set; }

        [JsonProperty("next")]
        public string NextUrl { get; set; }

        [JsonProperty("previous")]
        public string PreviousUrl { get; set; }

        [JsonProperty("results")]
        public List<Ship> Items { get; set; }
    }
}
