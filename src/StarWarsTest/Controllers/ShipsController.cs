using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsTest.Models.Responses;
using StarWarsTest.Services;

namespace StarWarsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private readonly SwApiServices _swApiServices;

        public ShipsController(SwApiServices swApiServices)
        {
            _swApiServices = swApiServices;
        }

        // GET: api/Ships
        [HttpGet("{distance}")]
        public ActionResult<List<ShipsResponse>> Get(int distance)
        {
            var ships = _swApiServices.GetListShips();

            if (ships == null || ships.Count == 0)
                return BadRequest();

            var outData = new List<ShipsResponse>();

            ships.ForEach(p =>
            {
                int.TryParse(p.MGLT, out int outNumber);

                var item = outNumber == 0 ? ShipsResponse.Add(p.Name, 0) : ShipsResponse.Add(p.Name, Convert.ToInt32(Math.Ceiling(distance / (double)outNumber)));

                outData.Add(item);
            });

            return outData;
        }
    }
}
