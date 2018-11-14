using Newtonsoft.Json;

namespace StarWarsTest.Models.Results
{
    public class Ship
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("MGLT")]
        public string  MGLT { get; set; }        
    }

}
