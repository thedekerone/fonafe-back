using Fonafe.SGI.Domain.Model.Financiera;
using Fonafe.SGI.Domain.Service.Inteface.Financial;
using Fonafe.SGI.Domain.Service.Service.Financial;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fonafe.SGI.WebApi.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CORS")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly IFlujoCajaRequestService _iFlujoCajaRequestService;
        private readonly IHostEnvironment _env;
        public FinancialController(
            IHostEnvironment env, IConfiguration configuration)
        {
           _iFlujoCajaRequestService = new FlujoCajaRequestService(configuration);
            _env = env;
        }

        // GET: api/<FinancyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _iFlujoCajaRequestService.ListFlujoCaja(new FlujoCaja());
            var json1 = new
            {
                isSuccess = result.Result.IsSuccess,
                data = result.Result,
                message = result.Exception
            };
            return Ok(JsonConvert.SerializeObject(json1));
        }

        // GET api/<FinancyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FinancyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FinancyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FinancyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
