using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CusApiController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CusApiController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("/name")]
        public IActionResult GetCus()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("custId/{id}")]
        public IActionResult GetCusId([FromRoute] int id)
        {
            var customersId = _context.Customers.Find(id);
            if (customersId == null)
            {
                return NotFound();
            }
            return Ok(customersId);
        }

        [HttpGet("custName/{name}")]
        public IActionResult GetCusName([FromRoute] string name)
        {
            var cus = _context.Customers.Where(cus => cus.Fullname.Contains(name));
            return Ok(cus);
        }
    }
}