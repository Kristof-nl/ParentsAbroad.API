using AutoMapper;
using ParentsAbroad.Contracts.Family;
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


        public async Task<IList<FamilyDto>> GetAllAsync(bool withRelations)
        {
            var families = withRelations ? await _familyRepository.GetFamiliesWithRelationsAsync() : await _familyRepository.GetAllAsync();
            return _mapper.Map<IList<FamilyDto>>(families);
        }

        public async Task<FamilyDto> GetByAsync(Expression<Func<Family, bool>> filter)
        {
            var family = await _familyRepository.GetByAsync(filter);
            return _mapper.Map<FamilyDto>(family);
        }

        public async Task<FamilyDto> GetByIdAsync(long id, bool withRelations)
        {
            var family = withRelations ? await _familyRepository.GetFamilyWithRelationsAsync(id) : await _familyRepository.GetByIdAsync(id);

            if (family == null) 
            {
                throw new Exception($"Family with id: {id} not found");
            }

            return _mapper.Map<FamilyDto>(family);
        }


        public async Task<FamilyDto> AddAsync(FamilyCreateUpdateDto familyCreateDto)
        {
            if (familyCreateDto.Id > 0)
            {
                throw new Exception("This item can't be added");
            }

            var family = _mapper.Map<Family>(familyCreateDto);

            var familyFromDb = await _familyRepository.SaveOrUpdateAsync(family);

            return _mapper.Map<FamilyDto>(familyFromDb);
        }

        public async Task<FamilyDto> UpdateAsync(FamilyCreateUpdateDto familyUpdateDto)
        {
            if (familyUpdateDto.Id == null || familyUpdateDto.Id == 0)
            {
                throw new Exception("This item can't be updated");
            }

            var family = _mapper.Map<Family>(familyUpdateDto);

            var familyFromDb = await _familyRepository.SaveOrUpdateAsync(family);

            return _mapper.Map<FamilyDto>(familyFromDb);
        }
    

        public async Task<bool> DeleteAsync(long id)
        {
            var family = await _familyRepository.GetByIdAsync(id);

            if (family == null)
            {
                throw new Exception($"Family with id: {id} not found");
            }
            else
            {
                return await _familyRepository.DeleteAsync(id);
            }
        }
    }
}
