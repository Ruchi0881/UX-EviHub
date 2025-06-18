using EviHub.Models.Entities;

namespace Evihub.Services
{
    public interface ICertificationService
    {
        Task<IEnumerable<Certification>> GetAllCertificationsAsync();
        Task<Certification> GetCertificationById(int id);
        Task AddCertificationsAsync(Certification certifications);
        Task  UpdateCertificationAsync(Certification certications);
        Task DeleteCertificationsAsync(int id);
    }
}
