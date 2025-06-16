using EviHub.Models.Entities;
namespace Evihub.Repositories
{
    public interface ICertificationCategoryRepository
    {
        Task<IEnumerable<CertificationCategory>> GetAllAsync();
        Task<CertificationCategory?> GetByIdAsync(int id);
        Task<CertificationCategory> AddAsync(CertificationCategory certification);
        Task<bool> UpdateAsync(CertificationCategory certification);
        Task<bool> DeleteAsync(int id);
        //Task<IEnumerable<Certification>> GetCertificationsByCategoryId(int id);
    }
}

    