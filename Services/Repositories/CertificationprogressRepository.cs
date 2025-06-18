using EviHub.Models.Entities;
using Evihub.Data;

using Microsoft.EntityFrameworkCore;
using EviHub.DTOs;

namespace Evihub.Repositories
{
    public class CertificationprogressRepository : ICertificationprogressRepository
    {
        private readonly EviHubDbContext _context;
        public CertificationprogressRepository(EviHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Certificationprogress>> GetAllAsync()
        {
            return await _context.Certificationprogress.ToListAsync();
           
        }
        public async Task<Certificationprogress> GetByIdAsync(int id) => await _context.Certificationprogress.FindAsync(id);
        public async Task<Certificationprogress> AddAsync(Certificationprogress progress)
        {
            _context.Certificationprogress.Add(progress);
            await _context.SaveChangesAsync();
            return progress;
        }
        public async Task UpdateAsync(Certificationprogress progress)
        {
            _context.Certificationprogress.Update(progress);
            await _context.SaveChangesAsync();
            
        }
        public async Task<bool> DeleteAsync(int id)
        {

            var cert = await _context.Certificationprogress.FindAsync(id);
            if (cert == null) return false;
            _context.Certificationprogress.Remove(cert);
            _context.SaveChanges();
            return true;
            
        } 
        
        public async Task<IEnumerable<CertificationprogressDTO>> GetByEmployeeIdAsync(int id)
        {


            var result = await (from cp in _context.Certificationprogress
                                join c in _context.Certifications
                                on cp.CertificationId equals c.CertificationId

                                select new CertificationprogressDTO
                                {
                                    CertificationProgressId = cp.CertificationProgressId,
                                    CertificationId = cp.CertificationId,
                                    CertificationName = c.CertificationName,
                                    EmpId = cp.EmpId,
                                    CompletionDate = cp.CompletionDate,
                                    Status = cp.Status,
                                    Comments = cp.Comments
                                }).ToListAsync();

            return result;
        }

        
        
        public async Task<List<Certificationprogress>> GetByCertificationIdAsync(int id)
        {
           var ex = await _context.Certificationprogress.Where(cp=> cp.CertificationId==id).ToListAsync();

            return ex;
        }

    }
}
