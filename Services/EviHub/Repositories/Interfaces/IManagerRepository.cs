using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetAllAsync();
        Task<Manager> AddAsync(Manager manager);
        Task<Manager> UpdateAsync(int id, Manager manager);
        Task<Manager> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
    

