﻿using AutoMapper;
using ParentsAbroad.Contracts;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Models.Models;
using System.Linq.Expressions;

namespace ParentsAbroad.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IMapper _mapper;

        public FamilyService(IFamilyRepository familyRepository, IMapper mapper)
        {
            _familyRepository = familyRepository;
            _mapper = mapper;
        }


        public async Task<IList<FamilyDto>> GetAllAsync()
        {
            var families = await _familyRepository.GetAllAsync();
            return _mapper.Map<IList<FamilyDto>>(families);
        }

        public async Task<FamilyDto> GetByAsync(Expression<Func<Family, bool>> filter)
        {
            var family = await _familyRepository.GetByAsync(filter);
            return _mapper.Map<FamilyDto>(family);
        }

        public async Task<FamilyDto> GetByIdAsync(long id)
        {
            var family = await _familyRepository.GetByIdAsync(id);

            if (family == null) 
            {
                throw new Exception($"Family with id: {id} not found");
            }

            return _mapper.Map<FamilyDto>(family);
        }


        public async Task<FamilyDto> AddAsync(FamilyCreateUpdateDto familyCreateDto)
        {
            if (familyCreateDto.Id != null || familyCreateDto.Id > 0)
            {
                throw new Exception("This item can't be added");
            }

            var family = _mapper.Map<Family>(familyCreateDto);

            var familyFromDb = _familyRepository.SaveOrUpdateAsync(family);

            return _mapper.Map<FamilyDto>(familyFromDb);
        }

        public async Task<FamilyDto> UpdateAsync(FamilyCreateUpdateDto familUpdateDto)
        {
            if (familUpdateDto.Id == null || familUpdateDto.Id == 0)
            {
                throw new Exception("This item can't be updated");
            }

            var family = _mapper.Map<Family>(familUpdateDto);

            var familyFromDb = _familyRepository.SaveOrUpdateAsync(family);

            return _mapper.Map<FamilyDto>(familyFromDb);
        }
    

        public async Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
