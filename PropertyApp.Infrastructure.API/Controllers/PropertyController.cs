using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PropertyApp.Infrastructure.Data.Contexts;
using PropertyApp.Infrastructure.Data.Repositories;
using PropertyApp.Applications.Services;
using PropertyApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyApp.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        PropertyService CreateService()
        {
            PropertyContext db = new PropertyContext();
            PropertyRepository repo = new PropertyRepository(db);
            PropertyService service = new PropertyService(repo);
            return service;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            var service = CreateService();
            return Ok(service.List());
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public ActionResult<Property> Get(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(Guid.Parse(id.ToString())));
        }

        // POST api/<PropertyController>
        [HttpPost]
        public ActionResult Post([FromBody] Property property)
        {
            var service = CreateService();
            service.Create(property);
            return Ok();
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Property property)
        {
            var service = CreateService();
            property.IdProperty = id;
            service.Update(property);
            return Ok();
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok();
        }
    }
}
