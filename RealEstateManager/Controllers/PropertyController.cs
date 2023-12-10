using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Application.Propertys.Validations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyServices;
        public PropertyController(IPropertyService propertyServices)
        {
            _propertyServices = propertyServices;
        }
        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listProperty = await _propertyServices.GetAllAsync();
            return Ok(listProperty);
        }

        // POST api/<PropertyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PropertyRequestDto propertyRequestDto)
        {
            var validator = new PropertyRequestValidator();
            var validationResult = validator.Validate(propertyRequestDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var propertyCreate = await _propertyServices.CreateAsync(propertyRequestDto);
            return Ok(propertyCreate);
        }

        // Patch api/<PropertyController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] ChangePriceProperty value)
        {
            var resultadoPatch = await _propertyServices.ChangePreciAsync(id, value);
            return Ok(resultadoPatch);
        }

        // Put api/<PropertyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PropertyRequestDto value)
        {
            var resultadoPut = await _propertyServices.UpdateAsync(id, value);
            return Ok(resultadoPut);
        }
    }
}