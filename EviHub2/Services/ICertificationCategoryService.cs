using EviHub.DTOs;
using EviHub.Models.Entities;

namespace EviHub.Services
{
    public interface ICertificationCategoryService
    {
        Task<IEnumerable<CertificationCategoryDTO>> GetAllAsync();
        Task<CertificationCategoryDTO> GetByIdAsync(int id);
        Task<CertificationCategoryDTO> AddAsync(CreateCertificationCategoryDTO dto);
        Task<bool> UpdateAsync(int id , UpdateCertificationCategoryDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Certification>> GetCertificationsByCategoryId(int id);
    }
}
