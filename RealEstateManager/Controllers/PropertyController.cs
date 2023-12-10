using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Application.Propertys.Validations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController(IPropertyService propertyServices) : ControllerBase
    {
        private readonly IPropertyService _propertyServices = propertyServices;

        // GET: api/<PropertyController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            var listProperty = await _propertyServices.GetAllAsync();
            return Ok(listProperty);
        }

        // POST api/<PropertyController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Patch(int id, [FromBody] ChangePriceProperty value)
        {
            var resultadoPatch = await _propertyServices.ChangePreciAsync(id, value);
            return Ok(resultadoPatch);
        }

        // Put api/<PropertyController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(int id, [FromBody] PropertyRequestDto value)
        {
            var validator = new PropertyRequestValidator();
            var validationResult = validator.Validate(value);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var resultadoPut = await _propertyServices.UpdateAsync(id, value);
            return Ok(resultadoPut);
        }

        [HttpPost("property/filters", Name = "getWithFilters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetWithFilters([FromForm] FiltersQuery filtersQuery)
        {
            var resultadoFilter = await _propertyServices.GetWithFilters(filtersQuery);
            return Ok(resultadoFilter);
        }
    }
}