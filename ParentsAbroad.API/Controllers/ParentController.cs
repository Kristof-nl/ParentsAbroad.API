using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Contracts;
using ParentsAbroad.Interfaces.Services;

namespace ParentsAbroad.API.Controllers
{
    [ApiController]
    [Route("api/parent")]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }


        [HttpGet]
        [Route("getallparents")]
        public async Task<ActionResult<IList<ParentDto>>> GetAllParent()
        {
            var parentDtos = await _parentService.GetAllAsync();
            return Ok(parentDtos);
        }

        [HttpGet]
        [Route("{familyId}")]
        public async Task<ActionResult<ParentDto>> GetFamilyById([FromRoute] long familyId)
        {
            var parentDto = await _parentService.GetByIdAsync(familyId);
            return Ok(parentDto);
        }

        [HttpGet]
        [Route("parentsfromfamily/{familyId}")]
        public async Task<ActionResult<IList<ParentDto>>> GetAllParentsFromFamily([FromRoute] long familyId)
        {
            var parentDtos = await _parentService.GetAllParentsFromFamilyAsync(familyId);
            return Ok(parentDtos);
        }

        [HttpPost]
        [Route("addtofamily")]
        public async Task<ActionResult<ParentDto>> AddParentToFamily([FromBody] ParentCreateUpdateDto parentCreateDto)
        {
            var parentDto = await _parentService.AddAsync(parentCreateDto);
            return Ok(parentDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ParentDto>> UpdateParent([FromBody] ParentCreateUpdateDto parentCreateDto)
        {
            var parentDto = await _parentService.UpdateAsync(parentCreateDto);
            return Ok(parentDto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ParentDto>> DeleteParent([FromRoute] long id)
        {
            var deleted = await _parentService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
