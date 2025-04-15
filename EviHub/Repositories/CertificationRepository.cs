using EviHub.Data;
using EviHub.EviHub.Core.Entities.MasterData;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class CertificationRepository
    {
        private readonly EviHubDbContext _context;

        public CertificationRepository(EviHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certification>> GetAllAsync()
        {
            return await _context.Certifications.ToListAsync();
        }

        public async Task<Certification> AddAsync(Certification certification)
        {
            _context.Certifications.Add(certification);
            await _context.SaveChangesAsync();
            return certification;
        }

        public async Task<Certification> UpdateAsync(int id, Certification certification)
        {
            var existing = await _context.Certifications.FindAsync(id);
            if (existing == null) return null;

            existing.CertificationName = certification.CertificationName;
            existing.CategoryId = certification.CategoryId;
            existing.IsActive = certification.IsActive;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cert = await _context.Certifications.FindAsync(id);
            if (cert == null) return false;

            _context.Certifications.Remove(cert);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

