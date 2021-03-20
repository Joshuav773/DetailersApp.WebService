using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DetailersApp.Repository.Models;
using DetailersApp.WebService.Envelope;
using DetailersApp.WebService.Service;
using Microsoft.AspNetCore.Mvc;
using static DetailersApp.WebService.Envelope.PotentialCustomerEnvelope;

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
        [ProducesResponseType(typeof(PotentialCustomerResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _custSvc.GetAllPotentialCustomers();
            if (!customers.Any())
            {
                return NotFound(new PotentialCustomerResponse()
                {
                    IsSuccess = false,
                    Results = customers,
                    Errors = new string[] { "No Potential Customers Found" }
                });
            }

            var ret = new PotentialCustomerResponse
            {
                IsSuccess = true,
                Results = customers,
                Errors = new string[] { }
            };

            return Ok(ret);
        }

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(typeof(PotentialCustomer), 200)]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    (PotentialCustomer result, string error) = await _custSvc.GetById(id);

        //    if (!string.IsNullOrEmpty(error) && error.Contains("Exception", StringComparison.OrdinalIgnoreCase))
        //        return StatusCode(500, $"There was an Exception in the proces. \n{ error }");

        //    if (!string.IsNullOrEmpty(error) && !error.Contains("Exception", StringComparison.OrdinalIgnoreCase))
        //        return StatusCode(500, $"{ error }");

        //    return Ok(result);
        //}
    }
}
