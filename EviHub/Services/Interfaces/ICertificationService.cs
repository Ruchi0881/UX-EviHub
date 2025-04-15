using EviHub.EviHub.Core.Entities.MasterData;
using EviHub.Models.DTO_s;

namespace EviHub.Services.Interfaces
{
    public interface ICertificationService
    {
        Task<IEnumerable<Certification>> GetAllCertificationsAsync();
        Task<Certification> AddCertificationAsync(CertificationDTO dto);
        Task<Certification> UpdateCertificationAsync(int id, CertificationDTO dto);
        Task<bool> DeleteCertificationAsync(int id);
    }
}
