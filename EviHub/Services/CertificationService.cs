using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;
using EviHub.Repositories.Interfaces;

namespace EviHub.Services
{
    public class CertificationService
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        public async Task<IEnumerable<Certification>> GetAllCertificationsAsync()
        {
            return await _certificationRepository.GetAllAsync();
        }

        public async Task<Certification> AddCertificationAsync(CertificationDTO dto)
        {
            var cert = new Certification
            {
                CertificationName = dto.CertificationName,
                CategoryId = dto.CategoryId,
                IsActive = dto.IsActive
            };

            return await _certificationRepository.AddAsync(cert);
        }

        public async Task<Certification> UpdateCertificationAsync(int id, CertificationDTO dto)
        {
            var cert = new Certification
            {
                CertificationName = dto.CertificationName,
                CategoryId = dto.CategoryId,
                IsActive = dto.IsActive
            };

            return await _certificationRepository.UpdateAsync(id, cert);
        }

        public async Task<bool> DeleteCertificationAsync(int id)
        {
            return await _certificationRepository.DeleteAsync(id);
        }
    }
}

