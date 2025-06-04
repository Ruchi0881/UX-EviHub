using EviHub.Data;
using EviHub.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EviHub.Repositories
{
    public class CertificationCategoryRepository : ICertificationCategoryRepository
    {
        private readonly EviHubDbContext _context;
        public CertificationCategoryRepository(EviHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CertificationCategory>> GetAllAsync()
        {
            return await _context.CertificationCategories.ToListAsync();
        }
        public async Task<CertificationCategory> GetByIdAsync(int id){
            return await _context.CertificationCategories.FindAsync(id);
        }
        public async Task<CertificationCategory> AddAsync(CertificationCategory category)
        {
            _context.CertificationCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> UpdateAsync(CertificationCategory category)
        {
            _context.CertificationCategories.Update(category);
            return await _context.SaveChangesAsync() > 0;
            
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var cert = await _context.CertificationCategories.FindAsync(id);
            if (cert == null) return false;
            _context.CertificationCategories.Remove(cert);
            _context.SaveChanges();
            return true;

        }
        public async Task<IEnumerable<Certification>> GetCertificationsByCategoryId(int id)
        {
           
            
            return await _context.Certifications.Where(c=>c.CategoryId == id).ToListAsync();
            
        }
    }
}
