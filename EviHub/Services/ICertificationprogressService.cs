using EviHub.DTOs;
using EviHub2.Models.Entities;

namespace EviHub.Services
{
    public interface ICertificationprogressService
    {
        Task<IEnumerable<CertificationprogressDTO>> GetAllAsync();
        Task<CertificationprogressDTO> GetAsync(int id);
        Task<CertificationprogressDTO> AddAsync(CreateCertificationprogressDTO dto);
        Task<bool> UpdateAsync(int id,UpdateCertificationprogressDTO dto); 
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CertificationprogressDTO>> GetByEmployeeId(int id);
        Task<IEnumerable<CertificationprogressDTO>> GetByCertificationId(int id);



    }
}
