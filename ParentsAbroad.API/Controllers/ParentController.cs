using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.Parent;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Shared.Dto;

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
        public async Task<ActionResult<IList<ParentDto>>> GetAllParent(bool withRelations = true)
        {
            var parentDtos = await _parentService.GetAllAsync(withRelations);
            return Ok(parentDtos);
        }

        [HttpGet]
        [Route("{parentId}")]
        public async Task<ActionResult<ParentDto>> GetParentById([FromRoute] long parentId, bool withRelations = true)
        {
            var parentDto = await _parentService.GetByIdAsync(parentId, withRelations);
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
        public async Task<ActionResult<ResponseResult<ParentDto>>> AddParentToFamily([FromBody] ParentCreateUpdateDto parentCreateDto)
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

        [HttpPost]
        [Route("addlanguage")]
        public async Task<ActionResult<ResponseResult<bool>>> AddLanguage([FromBody] AddLanguageDto addLanguageDto)
        {
            var added = await _parentService.AddLanguageAsync(addLanguageDto);
            return Ok(added);
        }
    }
}
