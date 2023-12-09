using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.Owners.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/<OwnerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _ownerService.GetAllAsync();
            return Ok(result);
        }
    }
}
