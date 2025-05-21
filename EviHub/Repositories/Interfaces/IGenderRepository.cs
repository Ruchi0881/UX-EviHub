using EviHub.EviHub.Core.Entities.MasterData;

namespace EviHub.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<Gender> AddAsync(Gender gender);
        Task<Gender> UpdateAsync(int id, Gender gender);
        Task<Gender> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
