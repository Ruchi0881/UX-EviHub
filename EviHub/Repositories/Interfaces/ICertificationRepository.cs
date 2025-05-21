using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface ICertificationRepository
    {
        Task<IEnumerable<Certification>> GetAllAsync();
        Task<Certification> GetByIdAsync(int id);
        Task<Certification> AddAsync(Certification certification);
        Task<Certification> UpdateAsync(int CertificationId, Certification certification);
        Task<bool> DeleteAsync(int CertificationId);
    }
}
