using System.Collections.Generic;
using EnergyLib;
using EnergyRestAPI.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnergyRestAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase{
        private EnergyManager manager = new EnergyManager();
        // GET: api/<EnergyController>
        [HttpGet]
        public ActionResult<IEnumerable<EnergyData>> Get([FromQuery] string sort){
            var result = manager.GetAll(sort);
            return Ok(result);
        }

        // GET api/<EnergyController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<EnergyController>
        [HttpPost]
        public ActionResult<EnergyData> Post([FromBody] EnergyData newData){
            manager.AddData(newData);
            return Created("api/energy/" + newData.Id, newData);
        }

        // PUT api/<EnergyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<EnergyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
