using EviHub.Data;
using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EviHubDbContext _context;

        public DesignationRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Designation>> GetAllAsync()
        {
            return await _context.Designations.ToListAsync();
        }

        public async Task<Designation> AddAsync(Designation designation)
        {
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public async Task<Designation> UpdateAsync(int id, Designation designation)
        {
            var existing = await _context.Designations.FindAsync(id);
            if (existing == null) return null;

            existing.DesignationName = designation.DesignationName;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<Designation> GetByIdAsync(int id)
        {
            return await _context.Designations
                .FirstOrDefaultAsync(d => d.DesignationId == id );
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var designation = await _context.Designations.FindAsync(id);
            if (designation == null) return false;

            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}

