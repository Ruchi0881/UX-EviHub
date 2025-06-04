using EviHub2.DTOs;
using EviHub2.Models.Entities;

namespace EviHub2.Services
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
