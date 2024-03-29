﻿using Microsoft.EntityFrameworkCore;
using ParentsAbroad.Interfaces.Repositories;
using ParentsAbroad.Models.DataContext;
using ParentsAbroad.Models.Models;

namespace ParentsAbroad.Repositories
{
    public class ChildRepository : BaseRepository<Child>, IChildRepository
    {
        private readonly ParentsAbroadDbContext _context;
        public ChildRepository(ParentsAbroadDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Child> GetByIdWithRelationsAsync(int childId)
        {
            return await _context.Children.Include(f => f.Family).Include(l => l.ChildLanguages).ThenInclude(x => x.Language)
                .Include(css => css.ChildSchoolSubjects).ThenInclude(ss => ss.SchoolSubject)
                .Include(ltd => ltd.ChildLikeToDoThings).ThenInclude(ltd => ltd.LikeToDo).FirstOrDefaultAsync(x => x.Id == childId);
        }

        public async Task<IList<Child>> GetAllChildrenWithRelationsAsync()
        {
            return await _context.Children.Include(f => f.Family).Include(l => l.ChildLanguages).ThenInclude(x => x.Language)
                .Include(css => css.ChildSchoolSubjects).ThenInclude(ss => ss.SchoolSubject)
                .Include(ltd => ltd.ChildLikeToDoThings).ThenInclude(ltd => ltd.LikeToDo).ToListAsync();
        }
    }
}
