using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using StarWarsTest.Models.Results;
using System;
using System.Collections.Generic;

namespace StarWarsTest.Services
{
    public class SwApiServices
    {
        private readonly IConfiguration _configuration;

        public SwApiServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Ship> GetListShips()
        {
            var swapiConfig = _configuration.GetSection("swapi");

            var url = swapiConfig.GetValue<string>("urllistships");

            var outData = new List<Ship>();

            var finish = false;

            while (!finish)
            {
                var result = GetData(url);

                if (result == null)
                {
                    finish = true;
                    continue;
                }

                if (result.Items != null)
                    outData.AddRange(result.Items);

                if (!string.IsNullOrEmpty(result.NextUrl))
                    url = result.NextUrl;
                else
                    finish = true;
            }

            return outData;
        }

        private StarShipsResult GetData(string url)
        {
            try
            {
                var client = new RestClient(url);

                var request = new RestRequest(Method.GET);

                request.AddHeader("Content-Type", "application/json");

                var data = client.Execute(request);

                var outData = JsonConvert.DeserializeObject<StarShipsResult>(data.Content);

                return outData;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
