using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.PopertyImages.Dto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController() : ControllerBase
    {


        // POST api/<PropertyImageController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] PropertyImageDto propertyImage)
        {
            return Ok("");
        }
    }
}