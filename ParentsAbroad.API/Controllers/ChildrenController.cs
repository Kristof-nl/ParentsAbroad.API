using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Shared.Dto;

namespace ParentsAbroad.API.Controllers
{
    [ApiController]
    [Route("api/child")]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildrenController(IChildService childService)
        {
            _childService = childService;
        }


        [HttpGet]
        [Route("getallchildren")]
        public async Task<ActionResult<IList<ChildDto>>> GetAllChildren()
        {
            var parentDtos = await _childService.GetAllAsync();
            return Ok(parentDtos);
        }

        [HttpGet]
        [Route("{childId}")]
        public async Task<ActionResult<ChildDto>> GetChildById([FromRoute] long familyId)
        {
            var parentDto = await _childService.GetByIdAsync(familyId);
            return Ok(parentDto);
        }

        [HttpGet]
        [Route("childrenfromfamily/{familyId}")]
        public async Task<ActionResult<IList<ChildDto>>> GetAllChildrenFromFamily([FromRoute] long familyId)
        {
            var parentDtos = await _childService.GetAllChildrenFromFamilyAsync(familyId);
            return Ok(parentDtos);
        }

        [HttpPost]
        [Route("addtofamily")]
        public async Task<ActionResult<ResponseResult<ChildDto>>> AddChildToFamily([FromBody] ChildCreateUpdateDto childCreateDto)
        {
            var parentDto = await _childService.AddAsync(childCreateDto);
            return Ok(parentDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ChildDto>> UpdateChild([FromBody] ChildCreateUpdateDto childCreateDto)
        {
            var parentDto = await _childService.UpdateAsync(childCreateDto);
            return Ok(parentDto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ChildDto>> DeleteChild([FromRoute] long id)
        {
            var deleted = await _childService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
