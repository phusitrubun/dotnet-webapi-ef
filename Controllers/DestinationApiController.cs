using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationApiController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DestinationApiController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("/DesZone")]
        public IActionResult GetDes()
        {
            var destination = _context.Destinations.Select(d => d.ToDesDTO());
            return Ok(destination);
        }

        [HttpGet("Des/{id}")]
        public IActionResult GetDesId([FromRoute] int id)
        {
            var destinationId = _context.Destinations.Find(id);
            if (destinationId == null)
            {
                return NotFound();
            }
            return Ok(destinationId.ToDesDTO());
        }

        [HttpGet("DesN/{zone}")]
        public IActionResult GetCusName([FromRoute] string zone)
        {
            var destinations = _context.Destinations.Where(d => d.Zone.Contains(zone)).Select(d => d.ToDesDTO());
            return Ok(destinations);
        }
    }
}
