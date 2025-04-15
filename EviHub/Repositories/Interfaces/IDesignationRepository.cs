using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAllAsync();
        Task<Designation> AddAsync(Designation designation);
        Task<Designation> UpdateAsync(int id, Designation designation);
        Task<bool> DeleteAsync(int id);
    }
}
