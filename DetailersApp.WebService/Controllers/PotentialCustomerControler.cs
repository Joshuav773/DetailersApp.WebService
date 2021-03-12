using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DetailersApp.WebService.Model;
using DetailersApp.WebService.Service;
using Microsoft.AspNetCore.Mvc;

namespace DetailersApp.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotentialCustomerController : ControllerBase
    {
        private PotentialCustomerService _custSvc;

        public PotentialCustomerController()
        {
            _custSvc = Startup.Container.Resolve<PotentialCustomerService>();
        }

        // GET api/values
        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<PotentialCustomer>), 200)]
        public async Task<IActionResult> GetAll()
        {
            (IEnumerable<PotentialCustomer> result, string error) = await _custSvc.GetAll();

            if (!string.IsNullOrEmpty(error) && error.Contains("Exception", StringComparison.OrdinalIgnoreCase))
                return StatusCode(500, $"There was an Exception in the proces. \n{ error}");

            if (!string.IsNullOrEmpty(error) && !error.Contains("Exception", StringComparison.OrdinalIgnoreCase))
                return StatusCode(500, $"{ error}");

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PotentialCustomer), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            (PotentialCustomer result, string error) = await _custSvc.GetById(id);

            if (!string.IsNullOrEmpty(error) && error.Contains("Exception", StringComparison.OrdinalIgnoreCase))
                return StatusCode(500, $"There was an Exception in the proces. \n{ error}");

            if (!string.IsNullOrEmpty(error) && !error.Contains("Exception", StringComparison.OrdinalIgnoreCase))
                return StatusCode(500, $"{ error}");

            return Ok(result);
        }
    }
}
