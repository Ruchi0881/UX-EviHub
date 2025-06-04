using System.Collections;
using EviHub.Models.Entities;

namespace EviHub.Repositories
{
    public interface ICertificationRepository
    {
        Task<IEnumerable<Certification>> GetAllCertificationsAsync();
        Task<Certification> GetCertificationById(int id);
        Task AddCertificationsAsync(Certification certifications);
        Task  UpdateCertificationAsync(Certification certifications);
        Task DeleteCertificationsAsync(int id);


    }
}













