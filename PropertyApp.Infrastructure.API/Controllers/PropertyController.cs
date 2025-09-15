using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PropertyApp.Infrastructure.Data.Contexts;
using PropertyApp.Infrastructure.Data.Repositories;
using PropertyApp.Applications.Services;
using PropertyApp.Domain;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyApp.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        PropertyService CreateService()
        {
            Data.Contexts.MainContext db = new Data.Contexts.MainContext();
            PropertyRepository repo = new PropertyRepository(db);
            PropertyImageRepository propertyImageRepository = new PropertyImageRepository(db);
            PropertyService service = new PropertyService(repo, propertyImageRepository);
            return service;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public ActionResult<List<Property>> Get([FromQuery] string? searchTerm, [FromQuery] double? minPrice, [FromQuery] double? maxPrice)
        {
            var service = CreateService();
            return Ok(service.List(searchTerm, minPrice, maxPrice));
        }

        // GET api/<PropertyController>/abc
        [HttpGet("{id}")]
        public ActionResult<Property> Get(string id)
        {
            var service = CreateService();
            return Ok(service.GetById(ObjectId.Parse(id.ToString())));
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
        public ActionResult Put(ObjectId id, [FromBody] Property property)
        {
            var service = CreateService();
            property.IdProperty = id;
            service.Update(property);
            return Ok();
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(ObjectId id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok();
        }
    }
}
