using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Interfaces.Services;
using ParentsAbroad.Models.Models;
using System.Linq.Expressions;

namespace ParentsAbroad.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        public FamilyService(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }


        public async Task<IList<Family>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Family> GetByAsync(Expression<Func<Family, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Family> GetByIdAsync(long id)
        {
            return await _familyRepository.GetByIdAsync(id);
        }


        public Task<Family> SaveOrUpdateAsync(Family family)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
