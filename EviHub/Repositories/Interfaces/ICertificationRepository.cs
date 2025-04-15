using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface ICertificationRepository
    {
        Task<IEnumerable<Certification>> GetAllAsync();
        Task<Certification> AddAsync(Certification certification);
        Task<Certification> UpdateAsync(int CertificatioId, Certification certification);
        Task<bool> DeleteAsync(int CertificationId);
    }
}
