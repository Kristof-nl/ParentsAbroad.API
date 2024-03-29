﻿using Microsoft.AspNetCore.Mvc;
using ParentsAbroad.Contracts.Hobby;
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

        #region CRUD

        [HttpGet]
        [Route("getallparents")]
        public async Task<ActionResult<IList<ParentDto>>> GetAllParent(bool withRelations = true)
        {
            var parentDtos = await _parentService.GetAllAsync(withRelations);
            return Ok(parentDtos);
        }

        [HttpGet]
        [Route("{parentId}")]
        public async Task<ActionResult<ParentDto>> GetParentById([FromRoute] int parentId, bool withRelations = true)
        {
            var parentDto = await _parentService.GetByIdAsync(parentId, withRelations);
            return Ok(parentDto);
        }

        [HttpGet]
        [Route("parentsfromfamily/{familyId}")]
        public async Task<ActionResult<IList<ParentDto>>> GetAllParentsFromFamily([FromRoute] int familyId)
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
        public async Task<ActionResult<ParentDto>> DeleteParent([FromRoute] int id)
        {
            var deleted = await _parentService.DeleteAsync(id);
            return Ok(deleted);
        }

        #endregion

        #region Language

        [HttpPost]
        [Route("addlanguage")]
        public async Task<ActionResult<ResponseResult<bool>>> AddLanguage([FromBody] AddLanguageDto addLanguageDto)
        {
            var added = await _parentService.AddLanguageAsync(addLanguageDto);
            return Ok(added);
        }

        [HttpDelete]
        [Route("deletelanguage/{parentId}/{languageId}")]
        public async Task<ActionResult<ParentDto>> DeleteLanguage([FromRoute] int parentId, int languageId)
        {
            var deleted = await _parentService.DeleteLanguageAsync(parentId, languageId);
            return Ok(deleted);
        }

        #endregion

        #region Hobby

        [HttpPost]
        [Route("addhobby")]
        public async Task<ActionResult<ResponseResult<bool>>> AddHobby([FromBody] AddHobbyDto addHobbyDto)
        {
            var added = await _parentService.AddHobbyAsync(addHobbyDto);
            return Ok(added);
        }

        [HttpDelete]
        [Route("deletehobby/{parentId}/{hobbyId}")]
        public async Task<ActionResult<ParentDto>> DeleteHobby([FromRoute] int parentId, int hobbyId)
        {
            var deleted = await _parentService.DeleteHobbyAsync(parentId, hobbyId);
            return Ok(deleted);
        }

        #endregion
    }
}
