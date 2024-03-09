using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Contracts;
using ParentsAbroad.Contracts.Child;
using ParentsAbroad.Contracts.Language;
using ParentsAbroad.Contracts.LikeToDo;
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

        #region

        [HttpGet]
        [Route("getallchildren")]
        public async Task<ActionResult<IList<ChildDto>>> GetAllChildren(bool withRelations = true)
        {
            var childDtos = await _childService.GetAllAsync(withRelations);
            return Ok(childDtos);
        }

        [HttpGet]
        [Route("{childId}")]
        public async Task<ActionResult<ChildDto>> GetChildById([FromRoute] long childId, bool withRelations = true)
        {
            var childDto = await _childService.GetByIdAsync(childId, withRelations);
            return Ok(childDto);
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
            var childDto = await _childService.AddAsync(childCreateDto);
            return Ok(childDto);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ChildDto>> UpdateChild([FromBody] ChildCreateUpdateDto childCreateDto)
        {
            var childDto = await _childService.UpdateAsync(childCreateDto);
            return Ok(childDto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ChildDto>> DeleteChild([FromRoute] long id)
        {
            var deleted = await _childService.DeleteAsync(id);
            return Ok(await _childService.DeleteAsync(id));
        }

        #endregion

        #region Language

        [HttpPost]
        [Route("addlanguage")]
        public async Task<ActionResult<ResponseResult<bool>>> AddLanguage([FromBody] AddLanguageDto addLanguageDto)
        {
            var added = await _childService.AddLanguageAsync(addLanguageDto);
            return Ok(added);
        }

        [HttpDelete]
        [Route("deletelanguage/{childId}/{languageId}")]
        public async Task<ActionResult<bool>> DeleteParent([FromRoute] long childId, long languageId)
        {
            var deleted = await _childService.DeleteLanguageAsync(childId, languageId);
            return Ok(deleted);
        }

        #endregion

        #region SchoolSubject

        [HttpPost]
        [Route("addschoolsubject")]
        public async Task<ActionResult<ResponseResult<bool>>> AddSchoolSubject([FromBody] AddSchoolSubjectDto addSchoolSubjectDto)
        {
            var added = await _childService.AddSchoolSubjectAsync(addSchoolSubjectDto);
            return Ok(added);
        }

        [HttpDelete]
        [Route("deleteschoolsubject/{childId}/{schoolSubjectId}")]
        public async Task<ActionResult<bool>> DeleteSchoolSubject([FromRoute] long childId, long schoolSubjectId)
        {
            var deleted = await _childService.DeleteSchoolSubjectAsync(childId, schoolSubjectId);
            return Ok(deleted);
        }

        #endregion

        #region LikeToDo

        [HttpPost]
        [Route("addliketodothing")]
        public async Task<ActionResult<ResponseResult<bool>>> AddLikeToDoThing([FromBody] LikeToDoAddDto addLikeToDoThingDto)
        {
            var added = await _childService.AddLikeToDoThingAsync(addLikeToDoThingDto);
            return Ok(added);
        }

        [HttpDelete]
        [Route("deleteliketodothing/{childId}/{liketodoId}")]
        public async Task<ActionResult<bool>> DeleteLikeToDoThing([FromRoute] long childId, long liketodoId)
        {
            var deleted = await _childService.DeleteLikeToDoThingAsync(childId, liketodoId);
            return Ok(deleted);
        }

        #endregion
    }
}
