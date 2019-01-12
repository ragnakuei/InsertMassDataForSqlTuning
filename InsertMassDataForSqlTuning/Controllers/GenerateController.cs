using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InsertMassDataForSqlTuning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly GenerateService _service;

        public GenerateController(GenerateService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            _service.Generate();
            return Ok();
        }
    }
}
