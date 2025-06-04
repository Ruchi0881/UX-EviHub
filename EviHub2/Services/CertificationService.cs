using EviHub.Models.Entities;
using EviHub.Repositories;

namespace EviHub.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository _repo;
        public CertificationService(ICertificationRepository repo)
        {
            _repo = repo;
        }
        public Task<IEnumerable<Certification>> GetAllCertificationsAsync()
        {
            return _repo.GetAllCertificationsAsync();
        }
        public async Task<Certification> GetCertificationById(int id)
        {
            return await _repo.GetCertificationById(id);
        }
        public async Task AddCertificationsAsync(Certification certification)
        {
            await _repo.AddCertificationsAsync(certification);
        }
        public async Task UpdateCertificationAsync(Certification certification)
        {
            var existing = await _repo.GetCertificationById(certification.CertificationId);
            if (existing == null)
            {
                throw new Exception("Certification not found");
            }
            existing.CertificationName = certification.CertificationName;
            existing.CategoryId = certification.CategoryId;
            existing.IsActive = certification.IsActive;
            await _repo.UpdateCertificationAsync(existing);
        }
        public async Task DeleteCertificationsAsync(int id)
        {
            var entity = await _repo.GetCertificationById(id);
            if(entity == null)
            {
                throw new Exception("Certification not found");
            }
            await _repo.DeleteCertificationsAsync(id);
        }

    }
}
