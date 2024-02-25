using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Contracts;

namespace ParentsAbroad.API.Controllers
{
    [ApiController]
    [Route("api/family")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FamilyDto>> GetFamilyById( [FromRoute] long id, bool withRelations = true)
        {
            var familyDto = await _familyService.GetByIdAsync(id, withRelations);
            return Ok(familyDto);
        }

        [HttpGet]
        [Route("families")]
        public async Task<ActionResult<IList<FamilyDto>>> GetAllFamilies([FromQuery] bool withRelations = true)
        {
            var familiesDto = await _familyService.GetAllAsync(withRelations);
            return Ok(familiesDto);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<FamilyDto>> AddFamily([FromBody] FamilyCreateUpdateDto familyCreateDto)
        {
            var familyDto = await _familyService.AddAsync(familyCreateDto);
            return Ok(familyDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<FamilyDto>> UpdateFamily([FromBody] FamilyCreateUpdateDto familyCreateDto)
        {
            var familyDto = await _familyService.UpdateAsync(familyCreateDto);
            return Ok(familyDto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteFamily([FromRoute] long id)
        {
            var deleted = await _familyService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
