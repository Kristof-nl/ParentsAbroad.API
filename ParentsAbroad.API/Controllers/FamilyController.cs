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
        [Route("getFamily/{id}")]
        public async Task<ActionResult<FamilyDto>> GetById( [FromRoute] long id)
        {
            var familyDto = await _familyService.GetByIdAsync(id);
            return Ok(familyDto);
        }
    }
}
