using EviHub.Data;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;
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

        public async Task<Gender> UpdateAsync(int Genderid, Gender gender)
        {
            var existing = await _context.Genders.FindAsync(Genderid);
            if (existing == null) return null;
            existing.GenderName = gender.GenderName;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int Genderid)
        {
            var gender = await _context.Genders.FindAsync(Genderid);
            if (gender == null) return false;
            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

