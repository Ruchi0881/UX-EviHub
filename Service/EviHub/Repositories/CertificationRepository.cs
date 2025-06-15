using System.Runtime.ConstrainedExecution;
using EviHub.Models.Entities;
using Evihub.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Evihub.Repositories
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly EviHubDbContext _context;
        public CertificationRepository(EviHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Certification>> GetAllCertificationsAsync()
        {
            return await _context.Certifications.ToListAsync();
        }
        public async Task<Certification> GetCertificationById(int id)
        {

            return await _context.Certifications.FindAsync(id);
        }
        public async Task AddCertificationsAsync(Certification Certification)
        {
            await _context.Certifications.AddAsync(Certification);
            await _context.SaveChangesAsync();
            
        }
        public async Task UpdateCertificationAsync(Certification Certification)
        {
            var existing = await _context.Certifications.FindAsync(Certification.CertificationId);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(Certification);
                await _context.SaveChangesAsync();
            }
             
        }
        public async Task DeleteCertificationsAsync(int id)
        {
            var certification = await _context.Certifications.FindAsync(id);
            if (certification != null)
            {

                _context.Certifications.Remove(certification);
                await _context.SaveChangesAsync();
                
            }
            
            
            
        }
    }
}













