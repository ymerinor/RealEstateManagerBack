using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.Property.Dto;
using RealEstateManager.Application.Property.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyServices _propertyServices;
        public PropertyController(IPropertyServices propertyServices)
        {
            _propertyServices = propertyServices;
        }
        // GET: api/<PropertyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropertyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PropertyRequestDto propertyRequestDto)
        {
            var propertyCreate = await _propertyServices.CreateAsync(propertyRequestDto);
            return Ok(propertyCreate);
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
