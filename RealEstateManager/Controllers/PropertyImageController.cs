using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyImageController(IPropertyImageService propertyImageService) : ControllerBase
    {
        private readonly IPropertyImageService _propertyImageService = propertyImageService;
        // POST api/<PropertyImageController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromForm] PropertyImageDto propertyImage)
        {
            var resultPropertyImage = await _propertyImageService.AddImagePropertyAsync(propertyImage);
            return Ok(resultPropertyImage);
        }
    }
}