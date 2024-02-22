using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Contracts;

namespace ParentsAbroad.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }

        [HttpGet]
        [Route("family/{id}")]
        public async Task<ActionResult<FamilyDto>> GetFamilyById( [FromRoute] long id)
        {
            var familyDto = await _familyService.GetByIdAsync(id);
            return Ok(familyDto);
        }

        [HttpGet]
        [Route("families")]
        public async Task<ActionResult<FamilyDto>> GetAllFamilies()
        {
            var familiesDto = await _familyService.GetAllAsync();
            return Ok(familiesDto);
        }


        [HttpPost]
        [Route("family/add")]
        public async Task<ActionResult<FamilyDto>> AddFamily([FromBody] FamilyCreateUpdateDto familyCreateDto)
        {
            var familiesDto = await _familyService.AddAsync(familyCreateDto);
            return Ok(familiesDto);
        }


    }
}
