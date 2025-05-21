using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface ICertificationService
    {
        Task<IEnumerable<CertificationDTO>> GetAllCertificationsAsync();
        Task<CertificationDTO> AddCertificationAsync(CertificationDTO dto);
        Task<CertificationDTO> UpdateCertificationAsync(int id, CertificationDTO dto);
        Task<CertificationDTO?> GetCertificationByIdAsync(int id);
        Task<bool> DeleteCertificationAsync(int id);
    }
}
