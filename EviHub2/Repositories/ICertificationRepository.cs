using System.Collections;
using EviHub2.Models.Entities;

namespace EviHub2.Repositories
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













