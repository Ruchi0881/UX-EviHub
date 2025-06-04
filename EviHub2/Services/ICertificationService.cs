using EviHub2.Models.Entities;

namespace EviHub2.Services
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
