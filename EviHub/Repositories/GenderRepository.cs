using EviHub.Data;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;
using Evihub.Data;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class GenderRepository:IGenderRepository
    {
        private readonly EviHubDbContext _context;
        public GenderRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
             return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> AddAsync(Gender gender)
        {
            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender> UpdateAsync(int id, Gender gender)
        {
            var existing = await _context.Genders.FindAsync(id);
            if (existing == null) return null;
            existing.GenderName = gender.GenderName;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<Gender> GetByIdAsync(int id)
        {
            return await _context.Genders
                .FirstOrDefaultAsync(g => g.GenderId == id);
        }
        

        public async Task<bool> DeleteAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null) return false;
            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

